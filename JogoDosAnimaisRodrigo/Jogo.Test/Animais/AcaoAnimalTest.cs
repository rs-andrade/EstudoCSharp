using Jogo.Animais;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jogo.Test.Animais
{
    [TestClass]
    public class AcaoAnimalTest
    {
        [TestMethod]
        public void DeveRetornarAcaoAnimalIgual()
        {
            var acaoCorrer = new AcaoAnimal{ Acao = "Correr"};

            var acaoCorrerNova = new AcaoAnimal { Acao = "Correr" };

            Assert.IsTrue(acaoCorrer.Equals(acaoCorrerNova));
        }

        [TestMethod]
        public void DeveRetornarAcaoAnimalDiferente()
        {
            var acaoCorrer = new AcaoAnimal { Acao = "Correr" };

            var acaoCorrerNova = new AcaoAnimal { Acao = "Correr2" };

            Assert.IsFalse(acaoCorrer.Equals(acaoCorrerNova));
        }
    }
}
