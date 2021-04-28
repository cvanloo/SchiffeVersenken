using SchiffeVersenken.Models;
using SchiffeVersenken.Enums;
using SchiffeVersenken.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SchiffeVersenken.Helpers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchiffeVersenken.Forms
{
    public partial class FormGamePreparation : Form
    {
        /* Member/Fields */

        private Form parentForm; // Parent-form, will be re-openend when this form is closed
        private GameMode gameMode;

        // User's objects
        private List<Field> fields;
        private List<Ship> ships;
        private SortedDictionary<Ship, PictureBox> shipPictures = new SortedDictionary<Ship, PictureBox>();
        private List<Mine> mines;
        private SortedDictionary<Mine, PictureBox> minePictures = new SortedDictionary<Mine, PictureBox>();

        // Used to draw the graphics
        private DrawGraphics drawGraphics;
        private Bitmap bitmap;

        private Player user;
        private Player enemy;

        // Used to position PictureBoxes
        private int posX = 15;
        private int posY = 530;

        private bool locked = false;

        /* Constructors */

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parentForm">The parent form</param>
        /// <param name="gameMode">The gamemode</param>
        /// <param name="user">The user</param>
        /// <param name="enemy">The enemy</param>
        public FormGamePreparation(Form parentForm, GameMode gameMode, Player user, Player enemy)
        {
            InitializeComponent();

            this.parentForm = parentForm;
            this.gameMode = gameMode;
            this.user = user;
            this.enemy = enemy;

            if (Settings.Default.s_Mine)
            {
                btnShowMines.Visible = true;
                btnShowShips.Visible = true;
                btnShowAll.Visible = true;
                posY = 580;
            }

            if (gameMode == GameMode.Host || gameMode == GameMode.Join)
            {
                btnChat.Enabled = true;
            }
            
            // Initialize graphics
            bitmap = new Bitmap(pbField.Width, pbField.Height);
            drawGraphics = new DrawGraphics(Graphics.FromImage(bitmap), bitmap.Width, bitmap.Height);

            // Create fields and ships (and mines)
            fields = BattlefieldCreator.CreateFields(bitmap.Width / 10);
            
            ships = BattlefieldCreator.CreateShips();
            InitializePictureBoxShips();

            if (Settings.Default.s_Mine)
            {
                mines = BattlefieldCreator.CreateMines(Settings.Default.s_MineNum);
                InitializePictureBoxMines();
            }

            // Draw battlefield
            ReloadImage();
        }

        /* Getter/Setter */

        /* Methods */

        /// <summary>
        /// Occurs the first time when the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGamePreparation_Load(object sender, EventArgs e)
        {
            // Helpdialogue
            if (Settings.Default.ShowHelpPreparation)
            {
                using (FormHelpDialogue fhd = new FormHelpDialogue(Settings.Default.HelpText, "Do not show this again"))
                {
                    fhd.ShowDialog();
                    Settings.Default.ShowHelpPreparation = !fhd.CheckState;
                    Settings.Default.Save(); // Save changes to settings
                }
            }
        }

        /// <summary>
        /// Give each ship a picturebox
        /// </summary>
        private void InitializePictureBoxShips()
        {
            foreach (Ship s in ships)
            {
                // Get dimensions of the current Ship
                int width = bitmap.Width / 10 * s.FieldCount - 4;
                int height = bitmap.Width / 10 - 4;

                Bitmap bmp = new Bitmap(width, height);

                // Draw ship gray
                Graphics grphx = Graphics.FromImage(bmp);
                grphx.FillRectangle(Brushes.Gray, 0, 0, bmp.Width, bmp.Height);

                // Initialize PictureBox
                PictureBox pictureBox = new PictureBox()
                {
                    Location = GetNextLocation(width, height, this.Width - 5),
                    Size = new Size(width, height),
                    Image = bmp
                };

                // Add Event-handlers to PictureBox
                pictureBox.MouseMove += new MouseEventHandler(PbShipMouseMove);
                pictureBox.MouseUp += new MouseEventHandler(PbShipMouseUp);
                pictureBox.MouseWheel += new MouseEventHandler(PbShipMouseWheel);

                // Add PictureBox to the form
                this.Controls.Add(pictureBox);
                pictureBox.BringToFront();

                // Map Ship and PictureBox together
                shipPictures.Add(s, pictureBox);
            }            
        }

        /// <summary>
        /// Give each mine a picturebox
        /// </summary>
        private void InitializePictureBoxMines()
        {
            foreach (Mine m in mines)
            {
                Bitmap bmp = new Bitmap(46, 46);

                // Draw mine gray
                DrawGraphics.DrawMine(bmp, Brushes.Gray);

                // Initialize PictureBox
                PictureBox pictureBox = new PictureBox()
                {
                    Location = GetNextLocation(46, 46, this.Width - 5),
                    Size = new Size(46, 46),
                    Image = bmp
                };

                // Add Event-handlers to PictureBox
                pictureBox.MouseMove += new MouseEventHandler(PbShipMouseMove);
                pictureBox.MouseUp += new MouseEventHandler(PbShipMouseUp);

                // Add PictureBox to the form
                this.Controls.Add(pictureBox);
                pictureBox.BringToFront();

                // Map Mine and PictureBox together
                minePictures.Add(m, pictureBox);
            }
        }

        /// <summary>
        /// Gets the next location for a PictureBoxShip
        /// </summary>
        /// <param name="sizeX">Width of the pbs</param>
        /// <param name="sizeY">Height of the pbs</param>
        /// <param name="maxX">Max length of a row</param>
        /// <returns></returns>
        private Point GetNextLocation(int sizeX, int sizeY, int maxX)
        {
            int newPosX = posX + sizeX + 5; // Next x
            int newPosY = posY; // Stay on y

            if (newPosX > maxX)
            {
                // If there isn't enough space left, start a new row
                posX = 15; // Set x back to start
                newPosX = posX + sizeX + 5; // Next x
                posY = posY + sizeY + 5; // Next y
                newPosY = posY; // Stay on y
            }

            Point location = new Point(posX, posY);
            posX = newPosX;
            posY = newPosY;

            return location;
        }

        /// <summary>
        /// Occurs when the mouse moves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbShipMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Left-Mouse-Button is pressed
            {
                // Reset highlighted fields
                ResetMarker();

                // Don't allow the user to drag the ship/mine outside the window
                if (PointToClient(Cursor.Position).X < 0 || PointToClient(Cursor.Position).Y < 0 || PointToClient(Cursor.Position).X > Width - 50 || PointToClient(Cursor.Position).Y > Height - 50)
                    return;

                // Make PictureBox follow mouse-cursor
                Point p = this.PointToClient(Cursor.Position);
                ((PictureBox)sender).Location = p;

                bool valid = false;
                List<Field> affectedFields = new List<Field>();

                KeyValuePair<Ship, PictureBox> kvpShip = shipPictures.FirstOrDefault(s => s.Value == ((PictureBox)sender));
                if (kvpShip.Key != null)
                {
                    affectedFields = GetAffectedFields(kvpShip, pbField.PointToClient(Cursor.Position), out valid);
                }
                else if (Settings.Default.s_Mine)
                {
                    Mine mine = minePictures.FirstOrDefault(m => m.Value == ((PictureBox)sender)).Key;
                    Field field = GetAffectedField(mine, pbField.PointToClient(Cursor.Position), out valid);

                    if (field != null)
                        affectedFields.Add(field);
                }                

                // Check position on battlefield and highlight fields
                if (affectedFields != null)
                {
                    foreach (Field fi in affectedFields.Where(fi => fi != null))
                    {
                        if (valid)
                            fi.FieldColor = Color.Green;
                        else
                            fi.FieldColor = Color.Red;
                    }
                }

                ReloadImage();
            }
        }

        /// <summary>
        /// Reset highlighted fields
        /// </summary>
        private void ResetMarker()
        {
            foreach (Field f in fields)
            {
                f.ApplyDefaultStyle();
            }
        }

        /// <summary>
        /// Occurs when a mouse button is released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbShipMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Left-Mouse-Button was released
            {
                ResetMarker();

                KeyValuePair<Ship, PictureBox> kvpShip = shipPictures.FirstOrDefault(s => s.Value == ((PictureBox)sender));
                if (kvpShip.Key != null)
                {
                    bool valid = false;
                    List<Field> fields = GetAffectedFields(kvpShip, pbField.PointToClient(Cursor.Position), out valid);
                    
                    if (valid)
                    {
                        // Place ship into battlefield
                        for (int i = 0; i < kvpShip.Key.FieldCount; i++)
                        {
                            kvpShip.Key.Fields[i] = fields[i];
                        }

                        // Hide PictureBox
                        kvpShip.Value.Hide();
                    }
                }
                else if (Settings.Default.s_Mine)
                {
                    KeyValuePair<Mine, PictureBox> kvpMine = minePictures.FirstOrDefault(m => m.Value == ((PictureBox)sender));

                    bool valid = false;
                    Field field = GetAffectedField(kvpMine.Key, pbField.PointToClient(Cursor.Position), out valid);

                    if (valid)
                    {
                        // Place mine into battlefield
                        kvpMine.Key.Position = field;

                        // Hide PictureBox
                        kvpMine.Value.Hide();
                    }
                }

                // Draw battlefield and ships
                ReloadImage();

                // Check if all ships and mines are placed on the battlefield
                if (shipPictures.Count(sp => sp.Value.Visible) == 0 && (!Settings.Default.s_Mine || minePictures.Count(mp => mp.Value.Visible) == 0))
                {
                    btnReady.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Get all fields that the ship hovers over
        /// </summary>
        /// <param name="ship">Ship</param>
        /// <param name="location">Position of the cursor relative to the battlefield</param>
        /// <param name="valid">True if the position of the ship is valid</param>
        /// <returns>Fields that the ships hovers over</returns>
        private List<Field> GetAffectedFields(KeyValuePair<Ship, PictureBox> kvpShip, Point location, out bool valid)
        {
            foreach (Field f in fields)
            {
                if (f.IsPointOnField(location))
                {
                    CheckField checkField = new CheckField(fields, ships, mines);
                    List<Field> affectedFields = new List<Field>();
                    int shipLength = kvpShip.Key.FieldCount;
                    bool isHorizontal = kvpShip.Value.Width > kvpShip.Value.Height;

                    // Get all fields
                    affectedFields.Add(f);
                    Field nextField = f;
                    for (int i = 1; i < shipLength; i++)
                    {
                        if (nextField == null) break;

                        if (isHorizontal)
                        {
                            // Ship is horizontal
                            nextField = fields.FirstOrDefault(fi => fi.PosX == nextField.PosX + nextField.Length && fi.PosY == nextField.PosY);
                        }
                        else
                        {
                            // Ship is vertical
                            nextField = fields.FirstOrDefault(fi => fi.PosY == nextField.PosY + nextField.Length && fi.PosX == nextField.PosX);
                        }

                        affectedFields.Add(nextField);
                    }

                    // Check fields
                    foreach (Field af in affectedFields)
                    {
                        if (!checkField.IsShipValid(af, isHorizontal, af == affectedFields[0]))
                        {
                            valid = false;
                            return affectedFields;
                        }
                    }

                    valid = true;
                    return affectedFields;
                }
            }

            valid = false;
            return null;
        }

        private Field GetAffectedField(Mine mine, Point location, out bool valid)
        {
            CheckField checkField = new CheckField(fields, ships, mines);

            foreach (Field f in fields)
            {
                if (f.IsPointOnField(location))
                {
                    valid = checkField.IsMineValid(f);
                    return f;
                }
            }

            valid = false;
            return null;
        }

        /// <summary>
        /// Change orientation of the ship
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbShipMouseWheel(object sender, MouseEventArgs e)
        {
            ChangeOrientationOfShip((PictureBox)sender);
        }

        /// <summary>
        /// Change the orientation of a picturebox
        /// </summary>
        /// <param name="pb">PictureBox to change</param>
        private void ChangeOrientationOfShip(PictureBox pb)
        {
            // Resize PicturBox, invert height and width
            Size oldSize = pb.Size;
            pb.Size = new Size(oldSize.Height, oldSize.Width);

            // Rotate image
            pb.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

        /// <summary>
        /// Reset positions of the ships
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReady.Enabled = false;

            // Reset ship position
            posX = 15;
            posY = Settings.Default.s_Mine ? 580 : 530;

            foreach (KeyValuePair<Ship, PictureBox> kvpShip in shipPictures)
            {
                kvpShip.Key.ClearFields();

                if (kvpShip.Value.Width < kvpShip.Value.Height)
                {
                    ChangeOrientationOfShip(kvpShip.Value);
                }

                kvpShip.Value.Location = GetNextLocation(kvpShip.Value.Width, kvpShip.Value.Height, this.Width - 5);
                kvpShip.Value.Visible = true;
            }
            
            if (Settings.Default.s_Mine)
            {
                foreach (KeyValuePair<Mine, PictureBox> kvpMine in minePictures)
                {
                    kvpMine.Key.ClearField();
                    kvpMine.Value.Location = GetNextLocation(kvpMine.Value.Width, kvpMine.Value.Height, this.Width - 5);
                    kvpMine.Value.Visible = true;
                }
            }

            // Redraw battlefield
            ReloadImage();
        }

        /// <summary>
        /// Redraws and reloads the battlefield-image
        /// </summary>
        private void ReloadImage()
        {
            drawGraphics.DrawFields(fields);
            drawGraphics.DrawBorder(Brushes.Black, 2);
            drawGraphics.DrawShips(ships);
            if (Settings.Default.s_Mine) drawGraphics.DrawMines(mines);
            pbField.Image = bitmap;
        }

        /// <summary>
        /// Show gamerules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRules_Click(object sender, EventArgs e)
        {
            using (FormHelpDialogue fhd = new FormHelpDialogue(Settings.Default.Rules))
            {
                fhd.ShowDialog();
            }
        }

        /// <summary>
        /// Wait for other player then start the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnReady_Click(object sender, EventArgs e)
        {
            locked = true; // Lock to make user unable to remove/replace a ship/mine

            btnReady.BackColor = Color.LimeGreen;
            btnReady.Enabled = false;
            btnReset.Enabled = false;
            btnRandomize.Enabled = false;

            // Initialize user
            user.Fields = fields;
            user.KnownShips = ships;
            user.KnownMines = mines;

            if (gameMode == GameMode.Host || gameMode == GameMode.Join)
            {
                EnemyNetwork enemyNetwork = (EnemyNetwork)enemy;
                enemyNetwork.SendMessage(user.KnownShips.Count);

                // Wait too receive enemys message
                int enemyShips = 0;
                await Task.Run(() => enemyShips = JsonConvert.DeserializeObject<int>(enemyNetwork.GetMessage()));
                enemyNetwork.SetShipsAlive = enemyShips;
            }
            
            // Start game
            FormGame formGame = new FormGame(user, enemy, gameMode, parentForm);
            formGame.Show();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Automatically set all ships at random positions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRandomize_Click(object sender, EventArgs e)
        {
            // Set ships to random positions
            try
            {
                RandomizeShipPositions.Randomize(ships, fields);
                if (Settings.Default.s_Mine) RandomizeShipPositions.Randomize(mines, ships, fields);
            }
            catch (Exception ex)
            {
                LogOutput.Output(ex.Message, LogOutput.LogType.Error);
                return;
            }

            // Hide PictureBoxes
            foreach (KeyValuePair<Ship, PictureBox> kvpShip in shipPictures)
            {
                kvpShip.Value.Hide();

                // If orientations don't match up, change orientation of the PictureBox
                bool isPbHorizontal = kvpShip.Value.Width > kvpShip.Value.Height;
                if (kvpShip.Key.IsHorizontal != isPbHorizontal)
                {
                    ChangeOrientationOfShip(kvpShip.Value);
                }
            }

            if (mines != null)
            {
                foreach (KeyValuePair<Mine, PictureBox> kvpMine in minePictures)
                {
                    kvpMine.Value.Hide();
                }
            }

            ReloadImage();
                
            btnReady.Enabled = true;
        }

        /// <summary>
        /// Open the chat window or bring it to the front, if it's already open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChat_Click(object sender, EventArgs e)
        {
            // Open chat or bring to front
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
        /// Detach an already placed ship
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbField_Click(object sender, EventArgs e)
        {
            if (locked) return;

            // Get position of mouse cursor
            Point pos = pbField.PointToClient(Cursor.Position);

            // Get ship at this position
            Field field = fields.FirstOrDefault(fi => fi.IsPointOnField(pos));

            if (field != null)
            {
                KeyValuePair<Ship, PictureBox> kvpShip = shipPictures.FirstOrDefault(k => k.Key == field.GetShipOnField(ships));
                //Ship ship = field.GetShipOnField(ships);

                if (kvpShip.Key != null)
                {
                    // Replace ship with shipItem-Picturebox
                    kvpShip.Value.Location = pos;
                    kvpShip.Key.ClearFields();
                    kvpShip.Value.Visible = true;
                    kvpShip.Value.BringToFront();

                    btnReady.Enabled = false;
                }
                else if (Settings.Default.s_Mine)
                {
                    KeyValuePair<Mine, PictureBox> kvpMine = minePictures.FirstOrDefault(k => k.Key == field.GetMineOnField(mines));
                    //Mine mine = field.GetMineOnField(mines);

                    if (kvpMine.Key != null)
                    {
                        // Replace mine with mineItem-Picturebox
                        kvpMine.Value.Location = pos;
                        kvpMine.Key.ClearField();
                        kvpMine.Value.Visible = true;
                        kvpMine.Value.BringToFront();

                        btnReady.Enabled = false;
                    }
                }

                ReloadImage();
            }
        }

        /// <summary>
        /// Occurs when the form is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGamePreparation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                if (gameMode != GameMode.Offline)
                {
                    DialogResult dialogResult = MessageBox.Show("Exit to main menu?\nYou will be disconnected from the game.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                
                // Show mainmenu
                parentForm.Show();

                // Clean up
                if (gameMode == GameMode.Join || gameMode == GameMode.Host)
                {
                    ((EnemyNetwork)enemy).StopListener();
                    ((EnemyNetwork)enemy).FormChatMsg.Close();
                }
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            btnShowAll.Enabled = false;
            btnShowShips.Enabled = true;
            btnShowMines.Enabled = true;

            foreach (KeyValuePair<Ship, PictureBox> kvpShip in shipPictures)
            {
                if (kvpShip.Key.Fields[0] == null)
                {
                    kvpShip.Value.Visible = true;
                }
            }

            foreach (KeyValuePair<Mine, PictureBox> kvpMine in minePictures)
            {
                if (kvpMine.Key.Position == null)
                {
                    kvpMine.Value.Visible = true;
                }
            }

            ReorderVisible();
        }

        private void btnShowShips_Click(object sender, EventArgs e)
        {
            btnShowShips.Enabled = false;
            btnShowAll.Enabled = true;
            btnShowMines.Enabled = true;

            foreach (KeyValuePair<Ship, PictureBox> kvpShip in shipPictures)
            {
                if (kvpShip.Key.Fields[0] == null)
                {
                    kvpShip.Value.Visible = true;
                }
            }

            foreach (KeyValuePair<Mine, PictureBox> kvpMine in minePictures)
            {
                kvpMine.Value.Visible = false;
            }

            ReorderVisible();
        }

        private void btnShowMines_Click(object sender, EventArgs e)
        {
            btnShowMines.Enabled = false;
            btnShowAll.Enabled = true;
            btnShowShips.Enabled = true;

            foreach (KeyValuePair<Ship, PictureBox> kvpShip in shipPictures)
            {
                kvpShip.Value.Visible = false;
            }

            foreach (KeyValuePair<Mine, PictureBox> kvpMine in minePictures)
            {
                if (kvpMine.Key.Position == null)
                {
                    kvpMine.Value.Visible = true;
                }
            }

            ReorderVisible();
        }

        private void ReorderVisible()
        {
            posX = 15;
            posY = 580;

            foreach (KeyValuePair<Ship, PictureBox> kvpShip in shipPictures)
            {
                if (kvpShip.Value.Visible)
                {
                    int width = bitmap.Width / 10 * kvpShip.Key.FieldCount - 4;
                    int height = bitmap.Width / 10 - 4;

                    kvpShip.Value.Location = GetNextLocation(width, height, this.Width - 5);
                }
            }

            foreach (KeyValuePair<Mine, PictureBox> kvpMine in minePictures)
            {
                if (kvpMine.Value.Visible)
                {
                    kvpMine.Value.Location = GetNextLocation(46, 46, this.Width - 5);
                }
            }
        }

        /// <summary>
        /// Show a help-dialogue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            using (FormHelpDialogue fhd = new FormHelpDialogue(Settings.Default.HelpText))
            {
                fhd.ShowDialog();
            }
        }
    }
}
