using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gregory.Models
{
    public class RoupaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da roupa")]
        [Display(Name = "Nome da Roupa")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a cor da roupa")]
        [Display(Name = "Cor da Roupa")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Informe se a roupa é estampada")]
        [Display(Name = "Status Estampa da Roupa")]
        public string Estampa { get; set; }

        [Required(ErrorMessage = "Informe o preço da roupa")]
        [Display(Name = "Preço da roupa")]
        public float Preco { get; set; }

        [Required(ErrorMessage = "Informe o sexo da roupa")]
        [Display(Name = "M/F/U")]
        [StringLength(1, MinimumLength = 1)]
        public string Sexo { get; set; }

        public FornecedorModel Fornecedor { get; set; }
    }
}