using System.Drawing;
using System.Windows.Forms;

namespace SchiffeVersenken.Extensions
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox textBox, string text, Color color)
        {
            textBox.SelectionStart = textBox.TextLength; // Set selection start to the end of the textbox
            textBox.SelectionLength = 0;

            textBox.SelectionColor = color;
            textBox.AppendText(text);
            textBox.SelectionColor = textBox.ForeColor; // Reset text color
        }

        public static void AppendText(this RichTextBox textBox, string text, Color color, float fontSize)
        {
            // Set selection start to the end of the textbox
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;

            // Set color and font
            textBox.SelectionColor = color;
            textBox.SelectionFont = new Font(FontFamily.GenericMonospace, fontSize);

            textBox.AppendText(text);
            
            // Reset color and font
            textBox.SelectionColor = textBox.ForeColor;
            textBox.SelectionFont = textBox.Font;
        }

        public static void AppendText(this RichTextBox textBox, string text, float fontSize)
        {
            // Set selection start to the end of the textbox
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;

            // Set font
            textBox.SelectionFont = new Font(FontFamily.GenericMonospace, fontSize);

            textBox.AppendText(text);

            // Reset font
            textBox.SelectionColor = textBox.ForeColor;
        }
    }
}
