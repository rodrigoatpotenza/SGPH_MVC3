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
        [Display(Name="Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage="Cidade é campo obrigatório.")]
        public long Cidades_Id { get; set; }

        [Required(ErrorMessage = "Estado é campo obrigatório.")]
        public long Cidades_Estados_Id { get; set; }

        [Required(ErrorMessage = "Unidade é campo obrigatório.")]
        public long Unidades_Id { get; set; }

        [Required(ErrorMessage = "Setor é campo obrigatório.")]
        public long Setores_Id { get; set; }

        [Required(ErrorMessage = "Cargo é campo obrigatório.")]
        public long Cargos_Id { get; set; }

        [Required(ErrorMessage = "Perfil é campo obrigatório.")]
        public long Perfis_Id { get; set; }

    }
}