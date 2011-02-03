using System;
using System.ComponentModel.DataAnnotations;

namespace SGPH.Models
{
    [MetadataType(typeof(ValidacaoFuncionario))]
    public partial class Funcionario {}

    public class ValidacaoFuncionario
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }
    }
}