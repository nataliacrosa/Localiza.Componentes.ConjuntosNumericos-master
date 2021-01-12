using Localiza.Componentes.ConjuntosNumericos.Models;
using Localiza.Componentes.ConjuntosNumericos.Services.Interfaces;
using System;
using System.Linq;

namespace Localiza.Componentes.ConjuntosNumericos.Services
{
    /// <summary>
    /// Classe responsavel por realizar os calculos referentes aos divisores.
    /// </summary>
    public class DivisoresService : IDivisoresService
    {
        /// <summary>
        /// Obtem os divisores de um determinado número.
        /// </summary>
        /// <param name="numeroEntrada">Número de entrada</param>
        /// <returns>Retorna o número de entrada e seus divisores.</returns>
        public NumerosDivisoresResponse ObterDivisores(long numeroEntrada)
        {
            return CalcularDivisores(numeroEntrada);
        }

        /// <summary>
        /// Obtem os divisores primos de um determinado número.
        /// </summary>
        /// <param name="numeroEntrada">Número de entrada</param>
        /// <returns>Retorna o número de entrada e seus divisores primos.</returns>
        public NumerosDivisoresPrimosResponse ObterDivisoresPrimos(long numeroEntrada)
        {
            return CalcularDivisoresPrimos(numeroEntrada);
        }

        private static NumerosDivisoresResponse CalcularDivisores(long numeroEntrada)
        {
            try
            {
                var numerosDivisores = new NumerosDivisoresResponse(numeroEntrada);

                for (long contador = 1; contador < (long)Math.Floor(Math.Sqrt(numeroEntrada)) + 1; contador++)
                {
                    if (numeroEntrada % contador == 0)
                    {
                        numerosDivisores.Divisores.Add(contador);
                    }
                }

                for (int contador = numerosDivisores.Divisores.Count; contador > 0; contador--)
                {
                    if (Math.Sqrt(numeroEntrada) != numerosDivisores.Divisores.ElementAt(contador - 1))
                    numerosDivisores.Divisores.Add(numeroEntrada / numerosDivisores.Divisores.ElementAt(contador - 1));
                }

                return numerosDivisores;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        private static NumerosDivisoresPrimosResponse CalcularDivisoresPrimos(long numeroEntrada)
        {
            try
            {
                var numerosDivisoresPrimos = new NumerosDivisoresPrimosResponse(numeroEntrada);

                var ehNumeroPrimo = true;

                for (long primeiroContador = 1; primeiroContador < (long)Math.Floor(Math.Sqrt(numeroEntrada)) + 1; primeiroContador++)
                {
                    if (numeroEntrada % primeiroContador == 0)
                    {
                        for (long segundoContador = 2; segundoContador < primeiroContador; segundoContador++)
                        {
                            if (primeiroContador % segundoContador == 0)
                            {
                                ehNumeroPrimo = false;
                                break;
                            }
                        }

                        if (ehNumeroPrimo)
                            numerosDivisoresPrimos.DivisoresPrimos.Add(primeiroContador);

                        ehNumeroPrimo = true;
                    }
                }

                return numerosDivisoresPrimos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }
    }
}
