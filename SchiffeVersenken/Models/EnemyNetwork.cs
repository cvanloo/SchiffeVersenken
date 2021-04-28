using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using SchiffeVersenken.Forms;
using SchiffeVersenken.Helpers;
using SchiffeVersenken.Enums;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace SchiffeVersenken.Models
{
    public class EnemyNetwork : Player
    {
        /* Fields/Members */

        private Socket listener; // Used to listen to incoming connections
        private Socket socketEnemy; // Socket to communicate with the enemy-player

        private Thread receiverThread; // Thread used to receive messages
        private Queue<string> receiverQueue = new Queue<string>();

        private DynamicShip dynamicShip = new DynamicShip(); // Stores all user-fields that are known to contain a ship, but the ship isn't sunken yet.

        private static FormChat formChatMsg;

        private int countShipsAlive;
        private int countShipsSunken;

        /* Constructors */

        public EnemyNetwork() : base(BattlefieldCreator.CreateFields(50))
        {
            receiverThread = new Thread(ReceiveMessage);

            KnownShips.Add(dynamicShip);
        }

        /* Getters/Setters */

        public FormChat FormChatMsg
        {
            get { return formChatMsg; }
            set { formChatMsg = value; }
        }

        public override int CountShipsAlive
        {
            get { return countShipsAlive; }
        }

        public override int CountShipsSunken
        {
            get { return countShipsSunken; }
        }

        public int SetShipsAlive
        {
            set { countShipsAlive = value; }
        }

        /* Methods */

        /// <summary>
        /// Wait for another player to connect
        /// </summary>
        /// <param name="ipAddress">Local IP from host</param>
        /// <returns></returns>
        public bool Host(IPAddress ipAddress, string username) // TODO: username known in parent-class
        {
            // Create listener
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 5000);
            try
            {
                listener.Bind(ipEndPoint);
            }
            catch (SocketException ex)
            {
                LogOutput.Output(ex.Message, LogOutput.LogType.Error);
                MessageBox.Show("Port 5000 is already in use. Close the application using port 5000 and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Wait for connection
            try
            {
                listener.Listen(10);
                socketEnemy = listener.Accept();
                receiverThread.Start();

                SendMessage(username);
                base.Username = JsonConvert.DeserializeObject<string>(GetMessage());

                formChatMsg = new FormChat(this);
            }
            catch (Exception ex)
            {
                if (!(ex is ThreadAbortException) && !(ex is SocketException))
                {
                    MessageBox.Show(ex.Message, "Error while waiting for client to connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.Error.WriteLine("EnemyNetwork.Host: " + ex.Message);
                }

                StopListener(); // Clean-up
                
                return false;
            }

            listener.Close();

            return true;
        }

        /// <summary>
        /// Connect to another player
        /// </summary>
        /// <param name="ipAddress">Local IP from other player</param>
        /// <returns></returns>
        public bool Join(IPAddress ipAddress, string username)
        {
            // Join host
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, 5000);
            socketEnemy = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socketEnemy.Connect(remoteEndPoint);
                receiverThread.Start();

                SendMessage(username);
                base.Username = JsonConvert.DeserializeObject<string>(GetMessage());
                formChatMsg = new FormChat(this);

                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("EnemyNetwork.Join: " + ex.Message);

                StopListener(); // Clean-up

                return false;
            }
        }

        /// <summary>
        /// Send a message as json to other player
        /// </summary>
        /// <param name="sendObject">Object to send</param>
        public void SendMessage<T>(T sendObject)
        {
            string jsonString = JsonConvert.SerializeObject(sendObject);
            byte[] msg = Encoding.ASCII.GetBytes(jsonString);

            if (msg.Length > 4096) throw new Exception("Message can't be longer than 4096 bytes.");

            socketEnemy.Send(msg);
            LogOutput.Output("Message sent: " + jsonString, LogOutput.LogType.Info);
        }

        /// <summary>
        /// Receives messages from other player
        /// Should be started in its own thread!
        /// </summary>
        private void ReceiveMessage()
        {
            try
            {
                while (true)
                {
                    String message = null;
                    byte[] bytes = null;

                    bytes = new byte[4096];
                    int bytesReceived = socketEnemy.Receive(bytes);
                    message += Encoding.ASCII.GetString(bytes, 0, bytesReceived);

                    string pattern = "^{\"Message\":\"(?s).*\",\"Sender\":\"(?s).*\"}$"; // Pattern of a ChatMessage-object: {"Message":"anything","Sender":"anything"} // (?s).* == any amount of symbols or whitespaces 
                    Regex regex = new Regex(pattern);
                    if (regex.IsMatch(message))
                    {
                        LogOutput.Output("Message is chat: " + message, LogOutput.LogType.Info);
                        ChatMessage cm = JsonConvert.DeserializeObject<ChatMessage>(message);
                        FormChatMsg.Messages.Enqueue(cm);
                        FormChatMsg.UpdateChat();
                    }
                    else
                    {
                        LogOutput.Output("Message is other: " + message, LogOutput.LogType.Info);
                        receiverQueue.Enqueue(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message + "\n" + ex.StackTrace);
                StopListener();
                // StopListener() aborts this thread, code below this line will not be executed!
            }
        }

        public string GetMessage(int timeout = 0)
        {
            int passed = 0;
            while (0 == receiverQueue.Count)
            {
                if (0 != timeout && passed < timeout)
                {
                    return null;
                }

                Thread.Sleep(50);
                passed += 50;
            }

            return receiverQueue.Dequeue();
        }

        /// <summary>
        /// Closes the listener and other threads
        /// </summary>
        public void StopListener()
        {
            if (listener != null)
            {
                listener.Close();
                listener.Dispose();
            }

            if (socketEnemy != null)
            {
                socketEnemy.Close();
                socketEnemy.Dispose();
            }

            if (receiverThread != null && receiverThread.IsAlive)
            {
                try
                {
                    receiverThread.Abort();
                }
                catch (ThreadAbortException) { }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        /// <summary>
        /// Receive a shot from the enemy and answer with miss, mine, hit or sunken
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>Miss, Mine, Hit or Sunken</returns>
        public ShotState Shoot(Player user)
        {
            // Revceive shot from enemy
            Shot shot = JsonConvert.DeserializeObject<Shot>(GetMessage());

            ShotState shotState = base.Shoot(shot, user);

            // If a mine was hit, sink the shooter
            if (ShotState.Mine == shotState)
            {
                foreach (Field fi in shot.Shooter.Fields)
                {
                    fi.Lifestate = FieldLifestate.Hit;
                }

                // Add ship to KnownShips
                KnownShips.Add(shot.Shooter);

                if (countShipsAlive >= 0) // TODO: No!
                {
                    countShipsAlive--;
                    countShipsSunken++;
                }
            }

            // Send shotstate to enemy
            SendMessage(shotState);

            return shotState;
        }

        public override ShotState ReceiveShot(Shot shot)
        {
            // Send shot to enemy
            SendMessage(shot);

            // Await ShotState from enemy
            ShotState shotState = JsonConvert.DeserializeObject<ShotState>(GetMessage());

            // Find shot field
            Field shotField = Fields.First(fi => fi.PosX == shot.TargetField.PosX && fi.PosY == shot.TargetField.PosY);

            // Register hit
            shotField.Lifestate = FieldLifestate.Hit;

            /* A player doesn't know the ships of its enemy, he needs to find out the position of the ships first.
             * A Ship is created when the player has found out all fields of a ship (when the ship is sunken).
             * Until then, all located fields are stored in a dynamic ship.
             */
            if (ShotState.Hit == shotState || ShotState.Sunken == shotState)
            {
                // Add field to dynamic ship
                dynamicShip.AddField(shot.TargetField);

                if (shotState == ShotState.Sunken)
                // Construct the sunken ship from the dynamic ship
                {
                    // Find fields that belong to targetfield
                    List<Field> fields = dynamicShip.GetBelongingFields(shot.TargetField);

                    // Add fields together in a ship
                    Ship ship = new Ship(fields.Count) { Fields = fields.ToArray() };

                    // Add ship to KnownShips
                    KnownShips.Add(ship);

                    if (countShipsAlive >= 0) // TODO: No!
                    {
                        countShipsAlive--;
                        countShipsSunken++;
                    }
                }
            }
            else if (shotState == ShotState.Mine)
            {
                // Add mine
                Mine mine = new Mine(shot.TargetField);
                KnownMines.Add(mine);

                // Sink the shooter
                foreach (Field fi in shot.Shooter.Fields)
                {
                    fi.Lifestate = FieldLifestate.Hit;
                }
            }

            return shotState;
        }
    }
}
