using System.Collections.Generic;

namespace Localiza.Componentes.ConjuntosNumericos.Models
{
    /// <summary>
    /// Entidade responsavel por representar os números divisores primos.
    /// </summary>
    public class NumerosDivisoresPrimosResponse : Base
    {
        /// <summary>
        /// Construtor que recebe o número de entrada e encaminha para a classe de herança.
        /// </summary>
        /// <param name="numeroEntrada">Número de entrada.</param>
        public NumerosDivisoresPrimosResponse(long numeroEntrada)
            : base(numeroEntrada)
        {
            DivisoresPrimos = new List<long>();
        }

        /// <summary>
        /// Lista contendo os divisores primos.
        /// </summary>
        public List<long> DivisoresPrimos { get; set; }
    }
}
