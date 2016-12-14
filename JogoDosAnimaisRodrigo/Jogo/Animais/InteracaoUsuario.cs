using Jogo.Animais.Interface;
using Jogo.Utils.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo.Animais
{
    public class InteracaoUsuario : IInteracaoUsuario
    {
        const string perguntaHabitat = "O animal que você pensou vive na água ?";
        const string perguntaAnimal = "O animal que você pensou é {0} ?";
        const string perguntaAcao = "O animal que você pensou {0} ?";
        const string avisoAcerto = "Acertei de novo!";
        const string perguntaQualAnimal = "Qual animal você pensou ?";
        const string captionPerguntaAnimal = "Desisto";
        const string perguntaAcaoNovoAnimal = "Um(a) {0} ______________ mas um(a) {1} não";
        const string captionPerguntaAcao = "Desisto";

        public bool PerguntarSeAnimalViveNaAgua()
        {
            return MessageQuestion.ConfirmationMessage(perguntaHabitat) == DialogResult.Yes;
        }

        public bool PerguntaSeAcertouAnimal(string nomeAnimal)
        {
            return MessageQuestion.ConfirmationMessage(String.Format(perguntaAnimal, nomeAnimal)) == DialogResult.Yes;
        }

        public void AvisarUsuarioAcerto()
        {
            MessageInformation.Show(avisoAcerto);
        }

        public bool PerguntaAcaoAnimal(AcaoAnimal acaoAnimal)
        {
            return MessageQuestion.ConfirmationMessage(String.Format(perguntaAcao, acaoAnimal.Acao)) == DialogResult.Yes;
        }

        public string PerguntaNomeNovoAnimal()
        {
            return MessageInput.ShowDialog(perguntaQualAnimal, captionPerguntaAnimal);
        }

        public string PerguntaAcaoNovoAnimal(string nomeNovoAnimal, string nomeAnimalReferencia)
        {
            return MessageInput.ShowDialog(string.Format(perguntaAcaoNovoAnimal, nomeNovoAnimal, nomeAnimalReferencia), captionPerguntaAcao);
        }
    }
}
