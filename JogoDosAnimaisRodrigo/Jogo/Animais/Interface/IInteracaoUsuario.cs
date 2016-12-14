namespace Jogo.Animais.Interface
{
    public interface IInteracaoUsuario
    {
        bool PerguntarSeAnimalViveNaAgua();
        bool PerguntaSeAcertouAnimal(string nomeAnimal);
        void AvisarUsuarioAcerto();
        bool PerguntaAcaoAnimal(AcaoAnimal acaoAnimal);
        string PerguntaNomeNovoAnimal();
        string PerguntaAcaoNovoAnimal(string nomeNovoAnimal, string nomeAnimalReferencia);
    }
}
