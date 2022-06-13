using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gregory.Models
{
    public class UsuarioModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email para login:")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 3)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Senha), ErrorMessage = "Sua senha não confere")]
        public string ConfirmarSenha { get; set; }

        [Required(ErrorMessage = "Informe o nível")]
        public string Nivel { get; set; }
    }
}