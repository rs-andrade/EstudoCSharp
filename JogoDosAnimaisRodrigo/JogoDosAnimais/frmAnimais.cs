using Jogo.Animais;
using System;
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
            var interacaoUsuario = new InteracaoUsuario();
            jogoDosAnimais.Adivinhar(interacaoUsuario);
        }
    }
}
