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
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a cor da roupa")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Informe se a roupa é estampada")]
        public string Estampa { get; set; }

        [Required(ErrorMessage = "Informe o preço da roupa")]
        public float Preco { get; set; }

        [Required(ErrorMessage = "Informe o sexo da roupa")]
        [StringLength(1, MinimumLength = 1)]
        public string Sexo { get; set; }

        public int? FornecedorId { get; set; }

        public FornecedorModel Fornecedor { get; set; }
    }
}