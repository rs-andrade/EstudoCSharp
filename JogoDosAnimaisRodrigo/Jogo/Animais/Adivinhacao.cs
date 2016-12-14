using Jogo.Animais.Interface;
using System.Collections.Generic;
using System.Linq;
using static Jogo.Animais.Enum.TipoAnimalEnum;

namespace Jogo.Animais
{
    public class Adivinhacao
    {
        public List<Animal> Animais { get; set; }

        public Adivinhacao()
        {
            Animais = new List<Animal>
            {
                new Animal {Nome = "Tubarão", TipoAnimal = TipoAnimal.Aquatico, Acoes = new List<AcaoAnimal>()},
                new Animal {Nome = "Macaco", TipoAnimal = TipoAnimal.Terrestre, Acoes = new List<AcaoAnimal>()}
            };
        }

        public ResultadoAdivinhacao Adivinhar(IInteracaoUsuario interacaoUsuario)
        {
            var acoesEscolhidas = new List<AcaoAnimal>();
            var animaisPorTipo = FiltrarAnimaisPorTipo(interacaoUsuario);
            var resultadoAdivinhacao = new ResultadoAdivinhacao();

            var animalselecionado = SelecionarUnicoAnimal(interacaoUsuario, acoesEscolhidas, animaisPorTipo);

            if (interacaoUsuario.PerguntaSeAcertouAnimal(animalselecionado.Nome))
            {
                resultadoAdivinhacao.Adivinhou = true;
                resultadoAdivinhacao.Animal = animalselecionado;
                interacaoUsuario.AvisarUsuarioAcerto();
            }
            else
            {
                resultadoAdivinhacao.Adivinhou = false;
                resultadoAdivinhacao.Animal = Animal.CriarAnimalPerguntando(animalselecionado, interacaoUsuario);
                Animais.Add(resultadoAdivinhacao.Animal);
            }

            return resultadoAdivinhacao;
        }        

        private IEnumerable<Animal> FiltrarAnimaisPorTipo(IInteracaoUsuario interacaoUsuario)
        {
            var viveNaAgua = interacaoUsuario.PerguntarSeAnimalViveNaAgua();
            return Animais.Where(o => o.TipoAnimal == (viveNaAgua ? TipoAnimal.Aquatico : TipoAnimal.Terrestre));
        }

        private Animal SelecionarUnicoAnimal(IInteracaoUsuario interacaoUsuario, List<AcaoAnimal> acoesEscolhidas, IEnumerable<Animal> animaisPorTipo)
        {
            while (animaisPorTipo.Count() > 1)
                animaisPorTipo = SelecionarAnimaisPorAcao(animaisPorTipo, acoesEscolhidas, interacaoUsuario);
            return animaisPorTipo.First();
        }

        private IEnumerable<Animal> SelecionarAnimaisPorAcao(IEnumerable<Animal> animais, List<AcaoAnimal> acoesJaEscolhidas,
            IInteracaoUsuario interacaoUsuario)
        {
            var animaisSelecionados = animais;
            var acoesAnimais = animaisSelecionados.SelectMany(o => o.Acoes).Distinct();
            foreach (var acaoAnimal in acoesAnimais)
            {
                if (acoesJaEscolhidas.Contains(acaoAnimal))
                    continue;

                if (interacaoUsuario.PerguntaAcaoAnimal(acaoAnimal))
                {
                    acoesJaEscolhidas.Add(acaoAnimal);
                    animaisSelecionados = animaisSelecionados.Where(x => x.Acoes.Contains(acaoAnimal));
                    break;
                }

                animaisSelecionados = animaisSelecionados.Where(x => !x.Acoes.Contains(acaoAnimal));
                break;
            }

            return animaisSelecionados;
        }
    }
}
