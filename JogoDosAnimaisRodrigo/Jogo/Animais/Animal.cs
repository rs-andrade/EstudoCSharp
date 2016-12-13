using Jogo.Utils.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jogo.Animais.Enum.TipoAnimalEnum;

namespace Jogo.Animais
{
    public class Animal
    {
        const string perguntaQualAnimal = "Qual animal você pensou ?";
        const string captionPerguntaAnimal = "Desisto";
        const string perguntaAcao = "Um(a) {0} ______________ mas um(a) {1} não";
        const string captionPerguntaAcao = "Desisto";

        public String Nome { get; set; }
        public String Acao { get; set; }
        public TipoAnimal TipoAnimal { get; set; }

        public static Animal CriarAnimalPerguntando(Animal animalReferencia)
        {
            var animal = new Animal();
            animal.Nome = MessageInput.ShowDialog(perguntaQualAnimal, captionPerguntaAnimal);
            animal.Acao = MessageInput.ShowDialog(string.Format(perguntaAcao, animal.Nome, animalReferencia.Nome), captionPerguntaAcao);
            animal.TipoAnimal = animalReferencia.TipoAnimal;
            return animal;
        }
    }
}
