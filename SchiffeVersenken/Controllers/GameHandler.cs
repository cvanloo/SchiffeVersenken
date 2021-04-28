using Newtonsoft.Json;
using SchiffeVersenken.Enums;
using SchiffeVersenken.Forms;
using SchiffeVersenken.Helpers;
using SchiffeVersenken.Models;
using SchiffeVersenken.Properties;
using System;
using System.Drawing;

namespace SchiffeVersenken.Controllers
{
    public class GameHandler
    {
        private GameMode gameMode;
        private Player user;
        private Player enemy;
        private FormGame formGame;
        private bool canUserShoot;
        private bool isGameOver = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gameMode">The gamemode being played</param>
        /// <param name="user">The user</param>
        /// <param name="enemy">The enemy</param>
        /// <param name="formGame">The game-form</param>
        public GameHandler(GameMode gameMode, Player user, Player enemy, FormGame formGame)
        {
            this.gameMode = gameMode;
            this.user = user;
            this.enemy = enemy;
            this.formGame = formGame;
        }

        /// <summary>
        /// Determines wether the user is allowed to shoot
        /// </summary>
        public bool CanUserShoot
        {
            get { return canUserShoot; }
        }

        /// <summary>
        /// True when the game is finished
        /// </summary>
        public bool IsGameOver
        {
            get { return isGameOver; }
        }

        public void Start()
        {
            if (gameMode == GameMode.Host || gameMode == GameMode.Offline)
            {
                /* Choose random between a 0 and 1.
                 * If the random value is 1, the bool is set to true, if it's 0 the bool is set to false
                 */
                canUserShoot = new Random().Next(0, 2) > 0;
            }

            NextTurn(null);
        }

        private void NextTurn(ShotState? shotState)
        {
            formGame.UpdateInfo();

            // Who can shoot?
            switch (gameMode)
            {
                case GameMode.Offline:
                    if (ShotState.Miss == shotState || ShotState.Mine == shotState) canUserShoot = !canUserShoot;
                    break;
                case GameMode.Join:
                    if (ShotState.Miss == shotState || ShotState.Mine == shotState) canUserShoot = !canUserShoot;
                    ((EnemyNetwork)enemy).SendMessage(!canUserShoot);
                    break;
                case GameMode.Host:
                    canUserShoot = JsonConvert.DeserializeObject<bool>(((EnemyNetwork)enemy).GetMessage());
                    break;
            }

            if (canUserShoot)
            // User can shoot
            {
                if (user.SelectedShip != null && user.SelectedShip.GetLifestate() == ShipLifestate.Sunken)
                {
                    user.SelectedShip = null;
                }

                formGame.DrawBattlefieldUser(Brushes.Black, 2);
                formGame.DrawBattlefieldEnemy(Brushes.LightGreen, 4);
                formGame.SetInfo("Your turn.");

                if (CountShipsAliveEnemy() <= 0)
                {
                    isGameOver = true;

                    // User won
                    formGame.SetInfo("Game Over - Victory!");
                    UpdateStatistics(true);
                    
                    if (gameMode == GameMode.Host || gameMode == GameMode.Join)
                    {
                        ((EnemyNetwork)enemy).FormChatMsg.Messages.Enqueue(new ChatMessage("You won!", SenderType.Info));
                        ((EnemyNetwork)enemy).FormChatMsg.UpdateChat();
                    }

                    formGame.ShowGameOver(true); // Exits the game
                }
                else
                {
                    if (gameMode == GameMode.Host || gameMode == GameMode.Join)
                    {
                        ((EnemyNetwork)enemy).FormChatMsg.Messages.Enqueue(new ChatMessage("Your turn.", SenderType.Info));
                        ((EnemyNetwork)enemy).FormChatMsg.UpdateChat();
                    }
                    
                    // Wait for user to shoot (Wait for user to click a field)
                }
            }
            else
            // Enemy can shoot
            {
                formGame.DrawBattlefieldUser(Brushes.Red, 4);
                formGame.DrawBattlefieldEnemy(Brushes.Black, 2);
                formGame.SetInfo("Enemy's turn.");

                if (CountShipsAliveUser() <= 0)
                {
                    isGameOver = true;

                    // Enemy won
                    formGame.SetInfo("Game Over - You lost!");
                    UpdateStatistics(false);

                    if (gameMode == GameMode.Host || gameMode == GameMode.Join)
                    {
                        ((EnemyNetwork)enemy).FormChatMsg.Messages.Enqueue(new ChatMessage("Enemy won.", SenderType.Info));
                        ((EnemyNetwork)enemy).FormChatMsg.UpdateChat();
                    }

                    formGame.ShowGameOver(false); // Exits the game
                }
                else
                {
                    if (gameMode == GameMode.Host || gameMode == GameMode.Join)
                    {
                        ((EnemyNetwork)enemy).FormChatMsg.Messages.Enqueue(new ChatMessage("Enemy's turn.", SenderType.Info));
                        ((EnemyNetwork)enemy).FormChatMsg.UpdateChat();
                    }

                    EnemyShoot();
                }
            }
        }

        public void UserShoot(Field targetField)
        {
            if (!canUserShoot) return;

            Shot shot = new Shot(user.SelectedShip, targetField);

            ShotState shotState = user.Shoot(shot, enemy);

            NextTurn(shotState);
        }

        public void EnemyShoot()
        {
            ShotState shotState = ShotState.Miss;

            switch (gameMode)
            {
                case GameMode.Offline:
                    shotState = ((EnemyComputer)enemy).Shoot(user);
                    break;
                case GameMode.Host:
                case GameMode.Join:
                    shotState = ((EnemyNetwork)enemy).Shoot(user);
                    break;
            }

            NextTurn(shotState);
        }

        /// <summary>
        /// Returns number of USER's ships that are still ALIVE
        /// </summary>
        /// <returns>Number of alive ships from USER</returns>
        public int CountShipsAliveUser()
        {
            return user.CountShipsAlive;
        }

        /// <summary>
        /// Returns number of ENEMY's ships that are still ALIVE
        /// </summary>
        /// <returns>Number of alive ships from ENEMY</returns>
        public int CountShipsAliveEnemy()
        {
            return enemy.CountShipsAlive;
        }

        /// <summary>
        /// Returns number of USER's ships that are SUNKEN
        /// </summary>
        /// <returns>Number of sunken ships from USER</returns>
        public int CountShipsSunkenUser()
        {
            return user.CountShipsSunken;
        }

        /// <summary>
        /// Returns number of ENEMY's ships that are SUNKEN
        /// </summary>
        /// <returns>Number of sunken ships from ENEMY</returns>
        public int CountShipsSunkenEnemy()
        {
            return enemy.CountShipsSunken;
        }

        /// <summary>
        /// Counts hits on USER's ships
        /// </summary>
        /// <returns>Number of hits on USER's ships</returns>
        public int CountHitsOnUser()
        {
            return user.CountHits;
        }

        /// <summary>
        /// Counts hits on ENEMY's ships
        /// </summary>
        /// <returns>Number of hits on ENEMY's ships</returns>
        public int CountHitsOnEnemy()
        {
            return enemy.CountHits;
        }

        /// <summary>
        /// Returns number of shots the USER made
        /// </summary>
        /// <returns>Number of shots from USER</returns>
        public int CountShotsFromUser()
        {
            return user.Shots.Count;
        }

        /// <summary>
        /// Returns number of shots the ENEMY made
        /// </summary>
        /// <returns>Number of shots from ENEMY</returns>
        public int CountShotsFromEnemy()
        {
            return enemy.Shots.Count;
        }

        /// <summary>
        /// Update statistics
        /// </summary>
        /// <param name="userWon">True if the user won</param>
        public void UpdateStatistics(bool userWon)
        {
            Settings.Default.GamesPlayed++;

            if (userWon)
            {
                int shotsCount = CountShotsFromUser();
                int shipsSunken = CountShipsSunkenUser();

                if (shotsCount < Settings.Default.FastestWin || Settings.Default.FastestWin == -1)
                {
                    Settings.Default.FastestWin = shotsCount;
                }

                if (Settings.Default.BestWin > shipsSunken || Settings.Default.BestWin == -1)
                {
                    Settings.Default.BestWin = shipsSunken;
                }

                Settings.Default.Wins++;
            }
            else
            {
                int shotsCount = CountShotsFromEnemy(); 
                int shipsSunken = CountShipsSunkenEnemy();

                if (shotsCount < Settings.Default.FastestLost || Settings.Default.FastestLost == -1)
                {
                    Settings.Default.FastestLost = shotsCount;
                }

                if (Settings.Default.WorstLose > shipsSunken || Settings.Default.WorstLose == -1)
                {
                    Settings.Default.WorstLose = shipsSunken;
                }

                Settings.Default.Loses++;
            }

            Settings.Default.Save(); // Save changes to settings
        }
    }
}
