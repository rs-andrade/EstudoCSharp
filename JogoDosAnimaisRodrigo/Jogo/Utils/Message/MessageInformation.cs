using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo.Utils.Message
{
    public class MessageInformation
    {
        public static void Show(string message)
        {
            MessageBox.Show(message);
        }
    }
}
