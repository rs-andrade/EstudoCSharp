using Jogo.Animais;
using Jogo.Animais.Enum;
using Jogo.Test.Animais.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Jogo.Test.Animais
{
    [TestClass]
    public class AnimalTest
    {
        [TestMethod]
        public void CriarAnimalComSucesso()
        {
            var animalReferencia = new Animal
            {
                Nome = "Cachorro",
                TipoAnimal = TipoAnimalEnum.TipoAnimal.Terrestre,
                Acoes = new List<AcaoAnimal>
                {
                    new AcaoAnimal {Acao = "Corre"},
                    new AcaoAnimal {Acao = "Morde"}
                }
            };

            var interacaoUsuario = new InteracaoUsuarioTest {
                AcaoNovoAnimal = "Salta",
                NomeNovoAnimal = "Cavalo"
            };

            var novoAnimal = Animal.CriarAnimalPerguntando(animalReferencia, interacaoUsuario);

            Assert.AreEqual(animalReferencia.TipoAnimal, novoAnimal.TipoAnimal);
            Assert.AreEqual(novoAnimal.Acoes.Count(x => x.Acao == "Corre" || x.Acao == "Morde" || x.Acao == "Salta"), 3);       
        }
    }
}
