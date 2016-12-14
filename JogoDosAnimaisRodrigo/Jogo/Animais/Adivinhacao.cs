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
        const string avisoAcerto = "Acertei de novo!";
        private List<Animal> animais;
        

        public Adivinhacao()
        {
            animais = new List<Animal>();
            animais.Add(new Animal { Nome = "Tubarão", TipoAnimal = TipoAnimal.Aquatico, Acoes = new List<AcaoAnimal>() });
            animais.Add(new Animal { Nome = "Macaco", TipoAnimal = TipoAnimal.Terrestre, Acoes = new List<AcaoAnimal>() });            
        }
        public void Adivinhar()
        {
            var acoesEscolhidas = new List<AcaoAnimal>(); ;
            var resultadoHabitat = MessageQuestion.ConfirmationMessage(perguntaHabitat);
            var animaisPorTipo = animais.Where(o => o.TipoAnimal == (resultadoHabitat == DialogResult.Yes ? TipoAnimal.Aquatico :
              TipoAnimal.Terrestre));

            while (animaisPorTipo.Count() != 1)
            {
                animaisPorTipo = SelecionarAnimaisPorAcao(animaisPorTipo, acoesEscolhidas);
            }

            PerguntaSeAcertou(animaisPorTipo.First());

        }

        private IEnumerable<Animal> SelecionarAnimaisPorAcao(IEnumerable<Animal> animaisPorTipo, List<AcaoAnimal> acoesEscolhidas)
        {
            var animaisSelecionados = animaisPorTipo;
            var acoesAnimais = animaisPorTipo.SelectMany(o => o.Acoes).Distinct();
            foreach (var acaoAnimal in acoesAnimais)
            {
                if (acoesEscolhidas.Contains(acaoAnimal))
                    animaisSelecionados = animaisSelecionados.Where(x => x.Acoes.Contains(acaoAnimal));
                else if (MessageQuestion.ConfirmationMessage(String.Format(perguntaAcao, acaoAnimal.Acao)) == DialogResult.Yes)
                {
                    acoesEscolhidas.Add(acaoAnimal);
                    animaisSelecionados = animaisSelecionados.Where(x => x.Acoes.Contains(acaoAnimal));                    
                }
                else
                {
                    animaisSelecionados = animaisSelecionados.Where(x => !x.Acoes.Contains(acaoAnimal));
                    break;
                }
                if (animaisSelecionados.Count() == 1)
                    break;

            }
            return animaisSelecionados;
        }

        private void PerguntaSeAcertou(Animal animal)
        {
            if (MessageQuestion.ConfirmationMessage(String.Format(perguntaAnimal, animal.Nome)) == DialogResult.Yes)
                MessageBox.Show(avisoAcerto);
            else
                animais.Add(Animal.CriarAnimalPerguntando(animal));
        }
    }
}
