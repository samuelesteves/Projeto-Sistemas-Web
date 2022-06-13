using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gregory.Models
{
    public class FornecedorModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do fornecedor")]
        [Display(Name = "Nome do Forncedor")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o do fornecedor")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email do Forncedor")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o status do fornecedor")]
        [Display(Name = "Status do Forncedor")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Informe o estado do fornecedor")]
        [Display(Name = "Estado do Forncedor")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe o país do fornecedor")]
        [Display(Name = "País do Forncedor")]
        public string Pais { get; set; }

        public virtual ICollection<RoupaModel> Roupas { get; set; }
    }
}