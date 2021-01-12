namespace Localiza.Componentes.ConjuntosNumericos.Models
{
    /// <summary>
    /// Representa a entidade base da aplicação.
    /// </summary>
    public class Base
    {
        /// <summary>
        /// Construtor que recebe o número de entrada.
        /// </summary>
        /// <param name="numeroEntrada"></param>
        public Base(long numeroEntrada)
        {
            NumeroEntrada = numeroEntrada;
        }

        /// <summary>
        /// Número de entrada informado pelo client da aplicação.
        /// </summary>
        public long NumeroEntrada { get; set; }
    }
}
