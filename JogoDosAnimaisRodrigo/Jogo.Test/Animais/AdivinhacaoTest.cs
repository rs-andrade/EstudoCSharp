using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jogo.Animais;
using Jogo.Test.Animais.Factory;

namespace Jogo.Test.Animais
{
    [TestClass]
    public class AdivinhacaoTest
    {        
        [TestMethod]
        public void AdivinharMacaco()
        {
            InteracaoUsuarioTest interacaoUsuario = CriarInteracao(false, true);
            var adivinhacao = new Adivinhacao();
            var resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(2, adivinhacao.Animais.Count);
            Assert.AreEqual("Macaco", resultado.Animal.Nome);
        }        

        [TestMethod]
        public void AdivinharTubarao()
        {
            InteracaoUsuarioTest interacaoUsuario = CriarInteracao(true, true);
            var adivinhacao = new Adivinhacao();
            var resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(2, adivinhacao.Animais.Count);
            Assert.AreEqual("Tubarão", resultado.Animal.Nome);
        }

        [TestMethod]
        public void AdivinharCavalo()
        {
            InteracaoUsuarioTest interacaoUsuario = CriarInteracao(false, false);
            interacaoUsuario.AcaoNovoAnimal = "Salta";
            interacaoUsuario.NomeNovoAnimal = "Cavalo";
            var adivinhacao = new Adivinhacao();
            var resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(3, adivinhacao.Animais.Count);
            Assert.AreEqual("Cavalo", resultado.Animal.Nome);
            interacaoUsuario.AcertouAcaoAnimal = true;
            interacaoUsuario.AcertouAnimal = true;
            resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(3, adivinhacao.Animais.Count);
            Assert.AreEqual("Cavalo", resultado.Animal.Nome);
        }

        [TestMethod]
        public void AdivinharCavaloESapo()
        {
            InteracaoUsuarioTest interacaoUsuario = CriarInteracao(false, false);
            interacaoUsuario.AcaoNovoAnimal = "Salta";
            interacaoUsuario.NomeNovoAnimal = "Cavalo";
            var adivinhacao = new Adivinhacao();
            var resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(3, adivinhacao.Animais.Count);
            Assert.AreEqual("Cavalo", resultado.Animal.Nome);
            interacaoUsuario.AcertouAcaoAnimal = true;
            interacaoUsuario.AcertouAnimal = true;
            resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(3, adivinhacao.Animais.Count);
            Assert.AreEqual("Cavalo", resultado.Animal.Nome);
            interacaoUsuario.AcertouAcaoAnimal = true;
            interacaoUsuario.AcertouAnimal = false;
            interacaoUsuario.AcaoNovoAnimal = "Lambe";
            interacaoUsuario.NomeNovoAnimal = "Sapo";
            resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(4, adivinhacao.Animais.Count);
            Assert.AreEqual("Sapo", resultado.Animal.Nome);
            interacaoUsuario.AcertouAcaoAnimal = true;
            interacaoUsuario.AcertouAnimal = true;
            resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(4, adivinhacao.Animais.Count);
            Assert.AreEqual("Sapo", resultado.Animal.Nome);
        }

        [TestMethod]
        public void AdivinharCavaloESapoEGato()
        {
            InteracaoUsuarioTest interacaoUsuario = CriarInteracao(false, false);
            interacaoUsuario.AcaoNovoAnimal = "Salta";
            interacaoUsuario.NomeNovoAnimal = "Cavalo";
            var adivinhacao = new Adivinhacao();
            var resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(3, adivinhacao.Animais.Count);
            Assert.AreEqual("Cavalo", resultado.Animal.Nome);
            interacaoUsuario.AcertouAcaoAnimal = true;
            interacaoUsuario.AcertouAnimal = true;
            resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(3, adivinhacao.Animais.Count);
            Assert.AreEqual("Cavalo", resultado.Animal.Nome);
            interacaoUsuario.AcertouAcaoAnimal = true;
            interacaoUsuario.AcertouAnimal = false;
            interacaoUsuario.AcaoNovoAnimal = "Lambe";
            interacaoUsuario.NomeNovoAnimal = "Sapo";
            resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(4, adivinhacao.Animais.Count);
            Assert.AreEqual("Sapo", resultado.Animal.Nome);
            interacaoUsuario.AcertouAcaoAnimal = true;
            interacaoUsuario.AcertouAnimal = true;
            resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(4, adivinhacao.Animais.Count);
            Assert.AreEqual("Sapo", resultado.Animal.Nome);
            interacaoUsuario.AcertouAcaoAnimal = false;
            interacaoUsuario.AcertouAnimal = false;
            interacaoUsuario.AcaoNovoAnimal = "Mia";
            interacaoUsuario.NomeNovoAnimal = "Gato";
            resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(5, adivinhacao.Animais.Count);
            Assert.AreEqual("Gato", resultado.Animal.Nome);
            interacaoUsuario.AcertouAcaoAnimal = false;
            interacaoUsuario.AcertouAnimal = true;
            resultado = adivinhacao.Adivinhar(interacaoUsuario);
            Assert.AreEqual(5, adivinhacao.Animais.Count);
            Assert.AreEqual("Gato", resultado.Animal.Nome);
        }

        private static InteracaoUsuarioTest CriarInteracao(bool viveNaAgua, bool acertouAnimal)
        {
            return new InteracaoUsuarioTest
            {
                AcaoNovoAnimal = "",
                NomeNovoAnimal = "",
                AcertouAcaoAnimal = true,
                AnimalViveNaAgua = viveNaAgua,
                AcertouAnimal = acertouAnimal
            };
        }        
    }
}
