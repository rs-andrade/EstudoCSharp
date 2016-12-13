using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo.Utils.Message
{
    public class MessageQuestion
    {
        const string captionConfirmation = "Confirmação";
        public static DialogResult ConfirmationMessage(string message)
        {
            return MessageBox.Show(message, captionConfirmation, MessageBoxButtons.YesNo);
        }
    }
}
