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
        [Display(Name = "Fornecedor")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o do fornecedor")]
        [DataType(DataType.EmailAddress)]
       
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o status do fornecedor")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Informe o estado do fornecedor")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe o país do fornecedor")]
        public string Pais { get; set; }

        public virtual ICollection<RoupaModel> Roupas { get; set; }
    }
}