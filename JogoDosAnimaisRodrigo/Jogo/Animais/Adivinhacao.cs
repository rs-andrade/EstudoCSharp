using Jogo.Animais.Enum;
using Jogo.Animais.Interface;
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
        private List<Animal> _animais;    

        public List<Animal> Animais
        {
            get
            {
                return _animais;
            }

            set
            {
                _animais = value;
            }
        }

        public Adivinhacao()
        {
            Animais = new List<Animal>();
            Animais.Add(new Animal { Nome = "Tubarão", TipoAnimal = TipoAnimal.Aquatico, Acoes = new List<AcaoAnimal>() });
            Animais.Add(new Animal { Nome = "Macaco", TipoAnimal = TipoAnimal.Terrestre, Acoes = new List<AcaoAnimal>() });
        }

        public ResultadoAdivinhacao Adivinhar(IInteracaoUsuario interacaoUsuario)
        {
            var acoesEscolhidas = new List<AcaoAnimal>();
            var animaisPorTipo = FiltrarAnimaisPorTipo(interacaoUsuario);
            var resultadoAdivinhacao = new ResultadoAdivinhacao();

            while (animaisPorTipo.Count() > 1)
                animaisPorTipo = SelecionarAnimaisPorAcao(animaisPorTipo, acoesEscolhidas, interacaoUsuario);

            if (interacaoUsuario.PerguntaSeAcertouAnimal(animaisPorTipo.First().Nome))
            {
                resultadoAdivinhacao.Adivinhou = true;
                resultadoAdivinhacao.Animal = animaisPorTipo.First();
                interacaoUsuario.AvisarUsuarioAcerto();
            }
            else
            {
                resultadoAdivinhacao.Adivinhou = false;
                resultadoAdivinhacao.Animal = Animal.CriarAnimalPerguntando(animaisPorTipo.First(), interacaoUsuario);
                Animais.Add(resultadoAdivinhacao.Animal);
            }

            return resultadoAdivinhacao;
        }

        private IEnumerable<Animal> FiltrarAnimaisPorTipo(IInteracaoUsuario interacaoUsuario)
        {
            var viveNaAgua = interacaoUsuario.PerguntarSeAnimalViveNaAgua();
            return Animais.Where(o => o.TipoAnimal == (viveNaAgua ? TipoAnimal.Aquatico : TipoAnimal.Terrestre));
        }

        private IEnumerable<Animal> SelecionarAnimaisPorAcao(IEnumerable<Animal> animais, List<AcaoAnimal> acoesJaEscolhidas,
            IInteracaoUsuario interacaoUsuario)
        {
            var animaisSelecionados = animais;
            var acoesAnimais = animais.SelectMany(o => o.Acoes).Distinct();
            foreach (var acaoAnimal in acoesAnimais)
            {
                if (acoesJaEscolhidas.Contains(acaoAnimal))
                    animaisSelecionados = animaisSelecionados.Where(x => x.Acoes.Contains(acaoAnimal));
                else if (interacaoUsuario.PerguntaAcaoAnimal(acaoAnimal))
                {
                    acoesJaEscolhidas.Add(acaoAnimal);
                    animaisSelecionados = animaisSelecionados.Where(x => x.Acoes.Contains(acaoAnimal));
                    break;
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
    }
}
