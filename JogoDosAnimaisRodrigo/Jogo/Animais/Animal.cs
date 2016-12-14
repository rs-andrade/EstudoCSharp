using Jogo.Animais.Interface;
using System;
using System.Collections.Generic;
using static Jogo.Animais.Enum.TipoAnimalEnum;

namespace Jogo.Animais
{
    public class Animal
    {
        public String Nome { get; set; }
        public List<AcaoAnimal> Acoes { get; set; }
        public TipoAnimal TipoAnimal { get; set; }

        public static Animal CriarAnimalPerguntando(Animal animalReferencia, IInteracaoUsuario interacaoUsuario)
        {
            var animal = new Animal();
            animal.Nome = interacaoUsuario.PerguntaNomeNovoAnimal();
            animal.Acoes = new List<AcaoAnimal>();
            animal.Acoes.AddRange(animalReferencia.Acoes);
            animal.Acoes.Add(new AcaoAnimal { Acao =  interacaoUsuario.PerguntaAcaoNovoAnimal(animal.Nome, animalReferencia.Nome)});
            animal.TipoAnimal = animalReferencia.TipoAnimal;
            return animal;
        }

        public override string ToString()
        {
            return Nome;
        }

    }
}
