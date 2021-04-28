using SchiffeVersenken.Enums;
using SchiffeVersenken.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SchiffeVersenken.Helpers
{
    public class DrawGraphics
    {
        /* Member/Fields */

        private Graphics graphics;
        private int width;
        private int height;

        /* Constructors */

        public DrawGraphics(Graphics graphics, int width, int height)
        {
            this.graphics = graphics;
            this.width = width;
            this.height = height;
        }

        /* Getter/Setter */

        /* Methods */

        public void DrawAll(Brush background, List<Field> fields, Brush highlightColor, int highlightThickness, List<Ship> ships)
        {
            // Draw background
            DrawBackground(background);

            // Draw fields
            DrawFields(fields);

            // Draw Border around battlefield
            DrawBorder(highlightColor, highlightThickness);

            // Draw ships with hits
            DrawShips(ships);
        }

        public void DrawAll(Brush background, List<Field> fields, Brush highlightColor, int highlightThickness, List<Ship> ships, List<Mine> mines)
        {
            // Draw background
            DrawBackground(background);

            // Draw fields
            DrawFields(fields);

            // Draw Border around battlefield
            DrawBorder(highlightColor, highlightThickness);

            // Draw ships with hits
            DrawShips(ships);

            // Draw mines with hits
            DrawMines(mines);
        }

        public void DrawAll(Brush background, List<Field> fields, Brush highlightColor, int highlightThickness, List<Ship> ships, List<Mine> mines,
            Brush selectedColor, int selectedSize, Ship selectedShip)
        {
            DrawAll(background, fields, highlightColor, highlightThickness, ships);

            // Draw mines with hits
            DrawMines(mines);

            // Draw selected ship
            DrawBorderAroundShip(selectedColor, selectedSize, selectedShip);
        }

        /// <summary>
        /// Draw the background of the battlefield
        /// </summary>
        /// <param name="color">Background-color</param>
        public void DrawBackground(Brush color)
        {
            graphics.FillRectangle(color, 0, 0, width, height);
        }

        /// <summary>
        /// Draw the background of the battlefield
        /// </summary>
        /// <param name="image">Background-image</param>
        public void DrawBackground(Image image)
        {
            // Draw image
            graphics.DrawImage(image, 0, 0, width, height);
        }

        /// <summary>
        /// Draw the fields for the battlefield
        /// </summary>
        /// <param name="fields">Fields to draw</param>
        public void DrawFields(List<Field> fields)
        {
            // Draw fields
            foreach (Field fi in fields)
            {
                SolidBrush b = new SolidBrush(fi.FieldColor);

                if (fi.Lifestate == FieldLifestate.Hit)
                {
                    b = (SolidBrush)Brushes.Gray;
                }

                graphics.FillRectangle(b, fi.PosX, fi.PosY, fi.Length, fi.Length);
                graphics.DrawRectangle(new Pen(fi.BorderColor, fi.BorderThickness), fi.PosX, fi.PosY, fi.Length - fi.BorderThickness, fi.Length - fi.BorderThickness);
            }
        }

        /// <summary>
        /// Draw the ships into the battlefield
        /// </summary>
        /// <param name="ships">Ships to draw</param>
        public void DrawShips(List<Ship> ships)
        {
            foreach (Ship s in ships)
            {
                foreach (Field fi in s.Fields)
                {
                    if (fi != null)
                    {
                        Brush brush = new SolidBrush(s.ShipColor);

                        if (s.GetLifestate() == ShipLifestate.Sunken)
                        {
                            brush = Brushes.Red;
                        }
                        else if (fi.Lifestate == FieldLifestate.Hit)
                        {
                            brush = Brushes.Orange;
                        }

                        graphics.FillRectangle(brush, fi.PosX, fi.PosY, fi.Length, fi.Length);
                    }
                }
            }
        }

        /// <summary>
        /// Draw a border around the battlefield
        /// </summary>
        /// <param name="highlightColor">Color of the border</param>
        /// <param name="highlightThickness">Thickness of the border</param>
        public void DrawBorder(Brush highlightColor, int highlightThickness)
        {
            graphics.DrawRectangle(new Pen(highlightColor, highlightThickness), highlightThickness / 2, highlightThickness / 2, width - highlightThickness, height - highlightThickness);
        }

        /// <summary>
        /// Draws a border around a ship
        /// </summary>
        /// <param name="borderColor">Color of the border</param>
        /// <param name="borderThickness">Thickness of the border</param>
        /// <param name="ship">Ship to draw the border around</param>
        public void DrawBorderAroundShip(Brush borderColor, int borderThickness, Ship ship)
        {
            int startX = ship.Fields.Min(f => f.PosX);
            int startY = ship.Fields.Min(f => f.PosY);
            Field fX = ship.Fields.FirstOrDefault(f => f.PosX == ship.Fields.Max(f => f.PosX));
            int endX = fX.PosX + fX.Length;
            Field fY = ship.Fields.FirstOrDefault(f => f.PosY == ship.Fields.Max(f => f.PosY));
            int endY = fY.PosY + fY.Length;

            endX -= startX;
            endY -= startY;

            graphics.DrawRectangle(new Pen(borderColor, borderThickness), startX, startY, endX, endY);
        }

        /// <summary>
        /// Converts degree to radian
        /// </summary>
        /// <param name="angle">Degree to convert</param>
        /// <returns>A radian</returns>
        private static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static void DrawMine(Bitmap bmp, Brush brush)
        {
            Point[] points = new Point[10];

            Point origin = new Point(bmp.Width / 2, bmp.Height / 2); // Center point of the circles
            int radiusOut = 20; // Radius of the outter circle
            int radiusIn = 10; // Radius of the inner circle

            int j = 0;
            for (int i = 0; i < 5; i++)
            {
                Point peak = new Point();
                double a = DegreeToRadian(i * 72);
                peak.X = (int)(origin.X + (radiusOut * Math.Cos(a)));
                peak.Y = (int)(origin.Y + (radiusOut * Math.Sin(a)));
                points[j++] = peak;

                a = DegreeToRadian((i * 72) + 36);
                peak.X = (int)(origin.X + (radiusIn * Math.Cos(a)));
                peak.Y = (int)(origin.Y + (radiusIn * Math.Sin(a)));
                points[j++] = peak;
            }

            Graphics graphics = Graphics.FromImage(bmp);
            graphics.FillPolygon(brush, points);
        }

        /// <summary>
        /// Draws the mines
        /// </summary>
        /// <param name="mines">Mines to draw</param>
        public void DrawMines(List<Mine> mines)
        {
            foreach (Mine m in mines)
            {
                if (m.Position != null)
                {
                    Brush brush;

                    if (m.GetLifestate() == ShipLifestate.Alive)
                    {
                        brush = Brushes.Black;
                    }
                    else
                    {
                        brush = Brushes.Red;
                    }

                    Field field = m.Position;
                    Point[] points = new Point[10];

                    Point origin = new Point(field.PosX + field.Length / 2, field.PosY + field.Length / 2); // Center point of the circles
                    int radiusOut = 20; // Radius of the outter circle
                    int radiusIn = 10; // Radius of the inner circle

                    // A true masterpice of art :^)
                    int j = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        Point peak = new Point();
                        double a = DegreeToRadian(i * 72);
                        peak.X = (int)(origin.X + (radiusOut * Math.Cos(a)));
                        peak.Y = (int)(origin.Y + (radiusOut * Math.Sin(a)));
                        points[j++] = peak;

                        a = DegreeToRadian((i * 72) + 36);
                        peak.X = (int)(origin.X + (radiusIn * Math.Cos(a)));
                        peak.Y = (int)(origin.Y + (radiusIn * Math.Sin(a)));
                        points[j++] = peak;
                    }

                    graphics.FillPolygon(brush, points);
                }
            }
        }
    }
}
