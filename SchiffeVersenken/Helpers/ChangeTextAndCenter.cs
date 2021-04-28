using System;

namespace SchiffeVersenken.Helpers
{
    public static class ChangeTextAndCenter
    {
        /* Member/Fields */

        /* Constructors */

        /* Getter/Setter */

        /* Methods */

        /// <summary>
        /// Change text and center a label in its parent-control
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="text">New text</param>
        public static void CenterTextIn(System.Windows.Forms.Label label, string text)
        {
            if (label.InvokeRequired)
            {
                // Invoke ensures that the code is executed on the thread that the control (label) lives on.
                label.Invoke(new Action(() => CenterTextIn(label, text)));
            }
            else
            {
                label.Hide();

                // Change text
                label.Text = text;

                // Center label in its parent
                int labelLength = label.Width;
                if (label.Parent == null) { throw new Exception("Label or Parent were null"); }
                int parentLength = label.Parent.Width;
                int newX = (parentLength - labelLength) / 2;
                label.Location = new System.Drawing.Point(newX, label.Location.Y);

                label.Show();
            }
        }

        /// <summary>
        /// Change text and center a label in a custom parent-control
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="text">New text</param>
        /// <param name="customParent">A control</param>
        public static void CenterTextIn(System.Windows.Forms.Label label, string text, System.Windows.Forms.Control customParent)
        {
            if (label.InvokeRequired)
            { 
                // Invoke ensures that the code is executed on the thread that the control (label) lives on.
                label.Invoke(new Action(() => CenterTextIn(label, text, customParent)));
            }
            else
            {
                label.Hide();

                // Change text
                label.Text = text;

                // Center label in its parent
                int labelLength = label.Width;
                if (label.Parent == null) { throw new Exception("Label or Parent were null"); }
                int parentLength = customParent.Width;
                int newX = (parentLength - labelLength) / 2;
                label.Location = new System.Drawing.Point(newX, label.Location.Y);

                label.Show();
            }
        }

        /// <summary>
        /// Change text and center a label on another control
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="text">New text</param>
        /// <param name="control">A control</param>
        public static void CenterTextOn(System.Windows.Forms.Label label, string text, System.Windows.Forms.Control control)
        {
            if (label.InvokeRequired)
            {
                // Invoke ensures that the code is executed on the thread that the control (label) lives on.
                label.Invoke(new Action(() => CenterTextIn(label, text, control)));
            }
            else
            {
                label.Hide();

                // Change text
                label.Text = text;

                // Center label in its parent
                int labelLength = label.Width;
                int parentLength = control.Width;
                int newX = (parentLength - labelLength) / 2;
                label.Location = new System.Drawing.Point(newX + control.Location.X, label.Location.Y);

                label.Show();
            }
        }
    }
}
