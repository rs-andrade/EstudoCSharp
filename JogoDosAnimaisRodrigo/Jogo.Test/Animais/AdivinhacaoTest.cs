using System;
using System.Text;
using System.Collections.Generic;
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
            var interacaoUsuario = new InteracaoUsuarioTest
            {
                AcaoNovoAnimal = "Salta",
                NomeNovoAnimal = "Cavalo",
                AcertouAcaoAnimal = true,
                AnimalViveNaAgua = false,
                AcertouAnimal = true
            };
            var adivinhacao = new Adivinhacao(interacaoUsuario);
        }
    }
}
