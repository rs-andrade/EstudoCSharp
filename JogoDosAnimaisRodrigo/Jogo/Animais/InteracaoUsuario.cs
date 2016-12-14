using Jogo.Animais.Interface;
using Jogo.Utils.Message;
using System.Windows.Forms;

namespace Jogo.Animais
{
    public class InteracaoUsuario : IInteracaoUsuario
    {
        private const string PerguntaHabitat = "O animal que você pensou vive na água ?";
        private const string PerguntaAnimal = "O animal que você pensou é {0} ?";
        private const string PerguntaAcao = "O animal que você pensou {0} ?";
        private const string AvisoAcerto = "Acertei de novo!";
        private const string PerguntaQualAnimal = "Qual animal você pensou ?";
        private const string TitlePerguntaAnimal = "Desisto";
        private const string PerguntaAcaoDoNovoAnimal = "Um(a) {0} ______________ mas um(a) {1} não";
        private const string TitlePerguntaAcao = "Desisto";

        public bool PerguntarSeAnimalViveNaAgua()
        {
            return MessageQuestion.ConfirmationMessage(PerguntaHabitat) == DialogResult.Yes;
        }

        public bool PerguntaSeAcertouAnimal(string nomeAnimal)
        {
            return MessageQuestion.ConfirmationMessage(string.Format(PerguntaAnimal, nomeAnimal)) == DialogResult.Yes;
        }

        public void AvisarUsuarioAcerto()
        {
            MessageInformation.Show(AvisoAcerto);
        }

        public bool PerguntaAcaoAnimal(AcaoAnimal acaoAnimal)
        {
            return MessageQuestion.ConfirmationMessage(string.Format(PerguntaAcao, acaoAnimal.Acao)) == DialogResult.Yes;
        }

        public string PerguntaNomeNovoAnimal()
        {
            return MessageInput.ShowDialog(PerguntaQualAnimal, TitlePerguntaAnimal);
        }

        public string PerguntaAcaoNovoAnimal(string nomeNovoAnimal, string nomeAnimalReferencia)
        {
            return MessageInput.ShowDialog(string.Format(PerguntaAcaoDoNovoAnimal, nomeNovoAnimal, nomeAnimalReferencia), TitlePerguntaAcao);
        }
    }
}
