namespace Localiza.Componentes.ConjuntosNumericos.Models
{
    /// <summary>
    /// Entidade responsavel por representar os erros ocorridos na aplicação.
    /// </summary>
    public class ErroResponse
    {
        /// <summary>
        /// Título do erro ocorrido.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descrição do erro ocorrido.
        /// </summary>
        public string Descricao { get; set; }
    }
}
