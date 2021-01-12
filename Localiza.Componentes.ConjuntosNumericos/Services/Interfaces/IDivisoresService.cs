using Localiza.Componentes.ConjuntosNumericos.Models;

namespace Localiza.Componentes.ConjuntosNumericos.Services.Interfaces
{
    /// <summary>
    /// Classe responsavel pela interface dos calculos referentes aos divisores.
    /// </summary>
    public interface IDivisoresService
    {
        /// <summary>
        /// Obtem os divisores de um determinado número.
        /// </summary>
        /// <param name="numeroEntrada">Número de entrada</param>
        /// <returns>Retorna o número de entrada e seus divisores.</returns>
        NumerosDivisoresResponse ObterDivisores(long numeroEntrada);

        /// <summary>
        /// Obtem os divisores primos de um determinado número.
        /// </summary>
        /// <param name="numeroEntrada">Número de entrada</param>
        /// <returns>Retorna o número de entrada e seus divisores primos.</returns>
        NumerosDivisoresPrimosResponse ObterDivisoresPrimos(long numeroEntrada);
    }
}
