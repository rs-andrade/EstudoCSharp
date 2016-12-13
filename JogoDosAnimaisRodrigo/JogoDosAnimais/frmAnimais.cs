using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDosAnimais
{
    public partial class frmAnimais : Form
    {
        private Jogo.Animais.Adivinhacao jogoDosAnimais;
        public frmAnimais()
        {
            InitializeComponent();
            jogoDosAnimais = new Jogo.Animais.Adivinhacao();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            jogoDosAnimais.Adivinhar();
        }
    }
}
