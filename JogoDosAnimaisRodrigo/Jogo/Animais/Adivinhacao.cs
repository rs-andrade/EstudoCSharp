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
        private IInteracaoUsuario _interacaoUsuario;       

        public Adivinhacao(IInteracaoUsuario interacaoUsuario)
        {
            _animais = new List<Animal>();
            _animais.Add(new Animal { Nome = "Tubarão", TipoAnimal = TipoAnimal.Aquatico, Acoes = new List<AcaoAnimal>() });
            _animais.Add(new Animal { Nome = "Macaco", TipoAnimal = TipoAnimal.Terrestre, Acoes = new List<AcaoAnimal>() });
            _interacaoUsuario = interacaoUsuario;         
        }
        public void Adivinhar()
        {
            var acoesEscolhidas = new List<AcaoAnimal>(); ;
            var viveNaAgua = _interacaoUsuario.PerguntarSeAnimalViveNaAgua();
            var animaisPorTipo = _animais.Where(o => o.TipoAnimal == (viveNaAgua ? TipoAnimal.Aquatico : TipoAnimal.Terrestre));

            while (animaisPorTipo.Count() != 1)
            {
                animaisPorTipo = SelecionarAnimaisPorAcao(animaisPorTipo, acoesEscolhidas);
            }

            if (_interacaoUsuario.PerguntaSeAcertouAnimal(animaisPorTipo.First().Nome))
                _interacaoUsuario.AvisarUsuarioAcerto();
            else
                _animais.Add(Animal.CriarAnimalPerguntando(animaisPorTipo.First(), _interacaoUsuario));

        }

        private IEnumerable<Animal> SelecionarAnimaisPorAcao(IEnumerable<Animal> animaisPorTipo, List<AcaoAnimal> acoesEscolhidas)
        {
            var animaisSelecionados = animaisPorTipo;
            var acoesAnimais = animaisPorTipo.SelectMany(o => o.Acoes).Distinct();
            foreach (var acaoAnimal in acoesAnimais)
            {
                if (acoesEscolhidas.Contains(acaoAnimal))
                    animaisSelecionados = animaisSelecionados.Where(x => x.Acoes.Contains(acaoAnimal));
                else if (_interacaoUsuario.PerguntaAcaoAnimal(acaoAnimal))
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
    }
}
