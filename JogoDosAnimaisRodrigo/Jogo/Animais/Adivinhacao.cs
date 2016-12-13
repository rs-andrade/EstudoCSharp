using Jogo.Animais.Enum;
using Jogo.Utils.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Jogo.Animais.Enum.TipoAnimalEnum;

namespace Jogo.Animais
{
    public class Adivinhacao
    {
        const string perguntaHabitat = "O animal que você pensou vive na água ?";
        const string perguntaAnimal = "O animal que você pensou é {0} ?";
        const string perguntaAcao = "O animal que você pensou {0} ?";
        const string avisoAcerto = "Acertei de novo! ?";
        private List<Animal> animais;

        public Adivinhacao()
        {
            animais = new List<Animal>();
            animais.Add(new Animal { Nome = "Tubarão", TipoAnimal = TipoAnimal.Aquatico, Acao = string.Empty });
            animais.Add(new Animal { Nome = "Macaco", TipoAnimal = TipoAnimal.Terrestre, Acao = string.Empty });
        }
        public void Adivinhar()
        {
            var resultadoHabitat = MessageQuestion.ConfirmationMessage(perguntaHabitat);
            var animaisPorTipo = animais.Where(o => o.TipoAnimal == (resultadoHabitat == DialogResult.Yes ? TipoAnimal.Aquatico :
              TipoAnimal.Terrestre));

            var acoesAnimais = animaisPorTipo ( )

            foreach (var animaldoUsuario in animaisPorTipo)
            {
                if (MessageQuestion.ConfirmationMessage(String.Format(perguntaAcao, animaldoUsuario.Acao)) == DialogResult.Yes)
                {
                    if (MessageQuestion.ConfirmationMessage(String.Format(perguntaAnimal, animaldoUsuario.Nome)) == DialogResult.Yes)
                        MessageBox.Show(avisoAcerto);
                    else
                        animais.Add(Animal.CriarAnimalPerguntando(animaldoUsuario));

                    return;
                }
            }

            var animal = animaisPorTipo.First();
            if (MessageQuestion.ConfirmationMessage(String.Format(perguntaAnimal, animal.Nome)) == DialogResult.Yes)
                MessageBox.Show(avisoAcerto);
            else
                animaisDoUsuario.Add(Animal.CriarAnimalPerguntando(animal));

        }
    }
}
