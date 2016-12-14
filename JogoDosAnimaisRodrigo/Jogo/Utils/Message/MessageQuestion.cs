using System.Windows.Forms;

namespace Jogo.Utils.Message
{
    public class MessageQuestion
    {
        private const string CaptionConfirmation = "Confirmação";
        public static DialogResult ConfirmationMessage(string message)
        {
            return MessageBox.Show(message, CaptionConfirmation, MessageBoxButtons.YesNo);
        }
    }
}
