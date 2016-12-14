using Jogo.Animais.Interface;
using System.Collections.Generic;
using static Jogo.Animais.Enum.TipoAnimalEnum;

namespace Jogo.Animais
{
    public class Animal
    {
        public string Nome { get; set; }
        public List<AcaoAnimal> Acoes { get; set; }
        public TipoAnimal TipoAnimal { get; set; }

        public static Animal CriarAnimalPerguntando(Animal animalReferencia, IInteracaoUsuario interacaoUsuario)
        {
            var animal = new Animal
            {
                Nome = interacaoUsuario.PerguntaNomeNovoAnimal(),
                Acoes = new List<AcaoAnimal>(),
                TipoAnimal = animalReferencia.TipoAnimal
            };
            animal.Acoes.AddRange(animalReferencia.Acoes);
            animal.Acoes.Add(new AcaoAnimal { Acao =  interacaoUsuario.PerguntaAcaoNovoAnimal(animal.Nome, animalReferencia.Nome)});
            return animal;
        }

        public override string ToString()
        {
            return Nome;
        }

    }
}
