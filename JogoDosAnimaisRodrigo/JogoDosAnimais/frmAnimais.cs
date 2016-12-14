using Jogo.Animais;
using System;
using System.Windows.Forms;

namespace JogoDosAnimais
{
    public partial class FrmAnimais : Form
    {
        private readonly Adivinhacao _jogoDosAnimais;

        public FrmAnimais()
        {
            InitializeComponent();
            
            _jogoDosAnimais = new Adivinhacao();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var interacaoUsuario = new InteracaoUsuario();
            _jogoDosAnimais.Adivinhar(interacaoUsuario);
        }
    }
}
