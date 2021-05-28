using System.ComponentModel.DataAnnotations;
using System;

namespace Projeto_API_REST.Models
{
    public class CartaoVirtual
    {   
        [Key]
        public int Id {get; set;}
        public string NumeroCartao {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Email {get; set;}

        public DateTime CreatedDate {get; set;}


        
    }
}