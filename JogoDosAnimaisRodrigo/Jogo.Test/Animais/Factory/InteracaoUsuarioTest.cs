using Jogo.Animais.Interface;
using Jogo.Animais;

namespace Jogo.Test.Animais.Factory
{
    public class InteracaoUsuarioTest : IInteracaoUsuario
    {
        public bool AcertouAcaoAnimal { get; set; }
        public string AcaoNovoAnimal { get; set; }
        public string NomeNovoAnimal { get; set; }
        public bool AnimalViveNaAgua { get; set; }
        public bool AcertouAnimal { get; set; }

        public void AvisarUsuarioAcerto()
        {
            return;
        }

        public bool PerguntaAcaoAnimal(AcaoAnimal acaoAnimal)
        {
            if (acaoAnimal.Acao == "Mia")
                return true;
            else
                return AcertouAcaoAnimal;
        }

        public string PerguntaAcaoNovoAnimal(string nomeNovoAnimal, string nomeAnimalReferencia)
        {
            return AcaoNovoAnimal;
        }

        public string PerguntaNomeNovoAnimal()
        {
            return NomeNovoAnimal;
        }

        public bool PerguntarSeAnimalViveNaAgua()
        {
            return AnimalViveNaAgua;
        }

        public bool PerguntaSeAcertouAnimal(string nomeAnimal)
        {
            return AcertouAnimal;
        }
    }
}
