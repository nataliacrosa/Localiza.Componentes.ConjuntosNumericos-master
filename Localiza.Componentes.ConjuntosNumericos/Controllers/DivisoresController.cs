using Localiza.Componentes.ConjuntosNumericos.Models;
using Localiza.Componentes.ConjuntosNumericos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Localiza.Componentes.ConjuntosNumericos.Controllers
{
    /// <summary>
    /// Controller responsavel pelas actions Divisores.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class DivisoresController : Controller
    {
        private readonly IDivisoresService _divisoresService;
        
        /// <summary>
        /// Constante para representar o maior número suportado pelo tipo long.
        /// </summary>
        private const long MaxValue = 9223372036854775807;
        
        /// <summary>
        /// Constante para representar o menor número inteiro.
        /// </summary>
        private const long MinValue = 0;

        private const string NumeroForaDoIntervaloEsperado = "O número informado está fora do intervalo esperado.";

        /// <summary>
        /// Construtor padrão que recebe as injeções de dependencia.
        /// </summary>
        /// <param name="divisoresService"></param>
        public DivisoresController(IDivisoresService divisoresService)
        {
            _divisoresService = divisoresService;
        }

        /// <summary>
        /// Calcula todos os divisores positivos que compõem o número de entrada.
        /// </summary>
        /// <param name="numeroEntrada">Número de entrada.</param>
        /// <returns>Retorna uma lista contendo todos os divisores.</returns>
        [HttpGet]
        public IActionResult CalculaDivisores([FromQuery] long numeroEntrada)
        {
            try
            {
                if (ValidarIntervalo(numeroEntrada))
                {
                    var result = _divisoresService.ObterDivisores(numeroEntrada);
                    return Ok(result);
                }

                return BadRequest(NumeroForaDoIntervaloEsperado);
            }
            catch (Exception ex)
            {
                return BadRequest(CompoemMensagemDeErro(ex));
            }
        }

        /// <summary>
        /// Calcula todos os divisores primos positivos que compõem o número de entrada.
        /// </summary>
        /// <param name="numeroEntrada">Número de entrada.</param>
        /// <returns>Retorna uma lista contendo todos os divisores primos.</returns>
        [HttpGet]
        public IActionResult CalculaDivisoresPrimos([FromQuery] long numeroEntrada)
        {
            try
            {
                if (ValidarIntervalo(numeroEntrada))
                {
                    var result = _divisoresService.ObterDivisoresPrimos(numeroEntrada);
                    return Ok(result);
                }

                return BadRequest(NumeroForaDoIntervaloEsperado);
            }
            catch (Exception ex)
            {
                return BadRequest(CompoemMensagemDeErro(ex));
            }
        }

        private static ErroResponse CompoemMensagemDeErro(Exception ex)
        {
            return new ErroResponse()
            {
                Titulo = "Ocorreu um erro ao processar a solicitação.",
                Descricao = $"{ex.Message}."
            };
        }

        private bool ValidarIntervalo(long numeroEntrada)
        {
            if (numeroEntrada > MinValue && numeroEntrada <= MaxValue)
            {
                return true;
            }

            return false;
        }
    }
}
