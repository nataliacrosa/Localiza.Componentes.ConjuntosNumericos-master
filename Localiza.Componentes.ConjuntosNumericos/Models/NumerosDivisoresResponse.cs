using System.Collections.Generic;

namespace Localiza.Componentes.ConjuntosNumericos.Models
{
    /// <summary>
    /// Entidade responsavel por representar os números divisores.
    /// </summary>
    public class NumerosDivisoresResponse : Base
    {
        /// <summary>
        /// Construtor que recebe o número de entrada e encaminha para a classe de herança.
        /// </summary>
        /// <param name="numeroEntrada">Número de entrada.</param>
        public NumerosDivisoresResponse(long numeroEntrada)
            : base(numeroEntrada)
        {
            Divisores = new List<long>();
        }

        /// <summary>
        /// Lista contendo os números divisores.
        /// </summary>
        public List<long> Divisores { get; set; }
    }
}
