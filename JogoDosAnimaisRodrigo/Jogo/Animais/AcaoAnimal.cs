using System;

namespace Jogo.Animais
{
    public class AcaoAnimal: IEquatable<AcaoAnimal>
    {
        public string Acao { get; set; }

        public bool Equals(AcaoAnimal other)
        {
            if (other == null)
                return false;

            return (Acao == other.Acao);
        }

        public override string ToString()
        {
            return Acao;
        }
    }
}