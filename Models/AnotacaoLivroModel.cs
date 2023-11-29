using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BookHub.Models
{
    public class AnotacaoLivroModel
    {
        [Key]
        public int IdAnotacaoLivro { get; set; }
        public LivroModel? Livro { get; set; }
        public AnotacaoModel? Anotacao { get; set; }
    }
}