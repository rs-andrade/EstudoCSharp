using Jogo.Animais;
using Jogo.Animais.Enum;
using Jogo.Test.Animais.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo.Test.Animais
{
    [TestClass]
    public class AnimalTest
    {
        [TestMethod]
        public void CriarAnimalComSucesso()
        {
            var animalReferencia = new Animal();
            animalReferencia.Nome = "Cachorro";
            animalReferencia.TipoAnimal = TipoAnimalEnum.TipoAnimal.Terrestre;
            animalReferencia.Acoes = new List<AcaoAnimal>();
            animalReferencia.Acoes.Add(new AcaoAnimal { Acao = "Corre" });
            animalReferencia.Acoes.Add(new AcaoAnimal { Acao = "Morde" });

            var interacaoUsuario = new InteracaoUsuarioTest {
                AcaoNovoAnimal = "Salta",
                NomeNovoAnimal = "Cavalo"
            };

            var novoAnimal = Animal.CriarAnimalPerguntando(animalReferencia, interacaoUsuario);

            Assert.AreEqual(animalReferencia.TipoAnimal, novoAnimal.TipoAnimal);
            Assert.AreEqual(novoAnimal.Acoes.Where(x => x.Acao == "Corre" || x.Acao == "Morde" || x.Acao == "Salta").Count(), 3);       
        }
    }
}
