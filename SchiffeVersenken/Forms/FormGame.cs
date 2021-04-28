using SchiffeVersenken.Models;
using SchiffeVersenken.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;
using SchiffeVersenken.Helpers;
using SchiffeVersenken.Controllers;
using System.Threading.Tasks;
using SchiffeVersenken.Properties;

namespace SchiffeVersenken.Forms
{
    public partial class FormGame : Form
    {
        /* Member/Fields */

        private const string textShots = "Total shots: ";
        private const string textHit = "Total hits: ";
        private const string textAlive = "Ships alive: ";
        private const string textSunken = "Ships sunken: ";

        private Player user;
        private Player enemy;

        private DrawGraphics graphicsUser;
        private DrawGraphics graphicsEnemy;
        private Bitmap bmpUser;
        private Bitmap bmpEnemy;

        private Form parentForm;
        private FormHelpDialogue fhd = new FormHelpDialogue(Settings.Default.Rules);

        private GameMode gameMode;
        private GameHandler gameHandler;

        /* Constructors */

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="enemy">The enemy</param>
        /// <param name="gameMode">The gamemode</param>
        /// <param name="parentForm">The parentform</param>
        /// <param name="timerInit">Countdown bevor the game starts</param>
        public FormGame(Player user, Player enemy, GameMode gameMode, Form parentForm)
        {
            InitializeComponent();

            this.user = user;
            this.enemy = enemy;
            this.gameMode = gameMode;
            this.parentForm = parentForm;
            
            ChangeTextAndCenter.CenterTextOn(labelEnemy, enemy.Username, pbFieldEnemy);

            // Enable button to open chat if playing against network-enemy
            if (gameMode == GameMode.Host || gameMode == GameMode.Join)
            {
                btnOpenChat.Enabled = true;
            }

            // Initialize graphics
            bmpUser = new Bitmap(pbFieldPlayer.Width, pbFieldPlayer.Height);
            bmpEnemy = new Bitmap(pbFieldPlayer.Width, pbFieldPlayer.Height);

            graphicsUser = new DrawGraphics(Graphics.FromImage(bmpUser), bmpUser.Width, bmpUser.Height);
            graphicsEnemy = new DrawGraphics(Graphics.FromImage(bmpEnemy), bmpEnemy.Width, bmpEnemy.Height);

            // Initialize gamehandler
            gameHandler = new GameHandler(gameMode, user, enemy, this);
        }

        /* Getter/Setter */

        /* Methods */

        private async void FormGame_Load(object sender, EventArgs e)
        {
            // Draw battlefield and update info
            UpdateInfo();
            DrawBattlefieldUser(Brushes.Black, 2);
            DrawBattlefieldEnemy(Brushes.Black, 2);

            if (gameMode == GameMode.Offline)
            {
                gameHandler.Start();
            }
            else
            {
                await Task.Run(() => gameHandler.Start());
            }
        }

        public void SetInfo(string text) 
        {
            ChangeTextAndCenter.CenterTextIn(labelInfo, text);
        }

        /// <summary>
        /// Register shots from user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pbFieldEnemy_Click(object sender, EventArgs e)
        {
            if (!gameHandler.CanUserShoot)
                return;

            if (Settings.Default.s_Mine && user.SelectedShip == null)
            {
                ChangeTextAndCenter.CenterTextIn(labelInfo, "Select a ship first!");
                return;
            }

            // Find out which field was clicked
            Point location = pbFieldEnemy.PointToClient(Cursor.Position);
            Field clickedField = null;
            foreach (Field fi in enemy.Fields)
            {
                if (fi.IsPointOnField(location))
                {
                    clickedField = fi;
                    break;
                }
            }

            // Check if field was not already shot
            if (clickedField != null && clickedField.Lifestate == FieldLifestate.Alive)
            {
                if (gameMode == GameMode.Host || gameMode == GameMode.Join)
                {
                    /* The await keyword allows to wait to receive the enemy's shot without blocking
                     * the UI-Thread.
                     */
                    await Task.Run(() => gameHandler.UserShoot(clickedField));
                }
                else
                {
                    gameHandler.UserShoot(clickedField);
                }
            }
        }

        /// <summary>
        /// Update the info text
        /// </summary>
        public void UpdateInfo()
        {
            if (InvokeRequired)
            {
                // Invoke ensures that the code is executed on the same thread that the control lives on.
                Invoke(new Action(() => UpdateInfo()));
            }
            else
            {
                // Update info total shots fired
                labelShots.Text = textShots + gameHandler.CountShotsFromEnemy();
                labelShotsEnemy.Text = textShots + gameHandler.CountShotsFromUser();

                // Update info ships alive
                labelShipsAlive.Text = textAlive + gameHandler.CountShipsAliveUser();
                labelShipsAliveEnemy.Text = textAlive + gameHandler.CountShipsAliveEnemy();

                // Update info ships sunken
                labelShipsFoundered.Text = textSunken + gameHandler.CountShipsSunkenUser();
                labelShipsFounderedEnemy.Text = textSunken + gameHandler.CountShipsSunkenEnemy();

                // Update info hits
                labelHits.Text = textHit + gameHandler.CountHitsOnEnemy();
                labelHitsEnemy.Text = textHit + gameHandler.CountHitsOnUser();
            }
        }

        /// <summary>
        /// Draw the battlefield of the user
        /// </summary>
        /// <param name="hlghtColorUser">Border-color of the battlefield</param>
        /// <param name="hlghtThicknessUser">Thickness of the border</param>
        public void DrawBattlefieldUser(Brush hlghtColorUser, int hlghtThicknessUser)
        {
            if (Settings.Default.s_Mine)
            {
                if (user.SelectedShip != null)
                    graphicsUser.DrawAll(Brushes.White, user.Fields, hlghtColorUser, hlghtThicknessUser, user.KnownShips, user.KnownMines, Brushes.Yellow, 3, user.SelectedShip);
                else
                    graphicsUser.DrawAll(Brushes.White, user.Fields, hlghtColorUser, hlghtThicknessUser, user.KnownShips, user.KnownMines);
            }
            else
            {
                graphicsUser.DrawAll(Brushes.White, user.Fields, hlghtColorUser, hlghtThicknessUser, user.KnownShips);
            }

            pbFieldPlayer.Image = bmpUser;
        }

        /// <summary>
        /// Draw the battlefield of the enemy
        /// </summary>
        /// <param name="hlghtColorEnemy">Border-color of the battlefield</param>
        /// <param name="hlghtThicknessEnemy">Thickness of the border</param>
        public void DrawBattlefieldEnemy(Brush hlghtColorEnemy, int hlghtThicknessEnemy)
        {
            if (Settings.Default.s_Mine)
                graphicsEnemy.DrawAll(Brushes.White, enemy.Fields, hlghtColorEnemy, hlghtThicknessEnemy, enemy.KnownShips, enemy.KnownMines);
            else
                graphicsEnemy.DrawAll(Brushes.White, enemy.Fields, hlghtColorEnemy, hlghtThicknessEnemy, enemy.KnownShips);

            pbFieldEnemy.Image = bmpEnemy;
        }

        /// <summary>
        /// Occurs when the form is being closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!gameHandler.IsGameOver)
            {
                DialogResult dialogResult = MessageBox.Show("Exit to main menu?\nYou will automatically lose the game.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }   
            }

            // Clean up
            if (gameMode == GameMode.Join || gameMode == GameMode.Host)
            {
                ((EnemyNetwork)enemy).StopListener();
                ((EnemyNetwork)enemy).FormChatMsg.Close();
            }

            fhd.Dispose();

            // Show mainmenu
            parentForm.Show();
        }

        /// <summary>
        /// Show if the user has won or lost
        /// </summary>
        /// <param name="isWin">True if the user has won</param>
        public void ShowGameOver(bool isWin)
        {
            FormWin formWin = new FormWin(isWin, gameHandler.CountShipsSunkenEnemy(), gameHandler.CountShipsSunkenUser());
            formWin.ShowDialog();
            Invoke(new Action(() => this.Close()));
        }

        /// <summary>
        /// Open the chat window or bring it to front, if it is already open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenChat_Click(object sender, EventArgs e)
        {
            EnemyNetwork networkEnemy = ((EnemyNetwork)enemy);
            if (!networkEnemy.FormChatMsg.Visible)
            {
                networkEnemy.FormChatMsg.Show();
            }
            else
            {
                networkEnemy.FormChatMsg.BringToFront();
            }
        }

        /// <summary>
        /// Open the rules window or bring it to front, if it is already open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowRules_Click(object sender, EventArgs e)
        {
            if (!fhd.Visible)
            {
                fhd.Show();
            }
            else
            {
                fhd.BringToFront();
            }
        }

        private void pbFieldPlayer_Click(object sender, EventArgs e)
        {
            if (Settings.Default.s_Mine)
            {
                // Find out which field was clicked
                Point location = pbFieldPlayer.PointToClient(Cursor.Position);
                Field clickedField = null;
                foreach (Field fi in user.Fields)
                {
                    if (fi.IsPointOnField(location))
                    {
                        clickedField = fi;
                        break;
                    }
                }

                Ship clickedShip = clickedField.GetShipOnField(user.KnownShips);

                if (clickedShip != null)
                {
                    // Check if field is already sunken
                    if (clickedShip.GetLifestate() == ShipLifestate.Alive)
                    {
                        user.SelectedShip = clickedShip;
                    }
                    else
                    {
                        ChangeTextAndCenter.CenterTextIn(labelInfo, "You can't select a sunken ship!");
                    }
                }

                DrawBattlefieldUser(Brushes.Black, 2);
            }
        }
    }
}
