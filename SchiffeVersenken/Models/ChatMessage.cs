using SchiffeVersenken.Enums;

namespace SchiffeVersenken.Models
{
    public class ChatMessage
    {
        /* Member/Fields */

        private string message;
        private SenderType sender;

        /* Constructors */
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="sender">The sender of the message</param>
        public ChatMessage(string message, SenderType sender)
        {
            this.message = message.TrimEnd('\r', '\n');
            this.sender = sender;
        }

        /* Getter/Setter */

        public string Message
        {
            get { return message; }
        }

        public SenderType Sender
        {
            get { return sender; }
        }

        /* Methods */

    }
}
