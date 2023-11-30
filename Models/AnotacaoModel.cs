using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookHub.Models
{
    public class AnotacaoModel
    {
        [Key]
        public int IdAnotacao { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Categoria { get; set; }
        public string Cor { get; set; }

        [ForeignKey("Livro")]
        public int IdLivro { get; set; }
        public LivroModel Livro { get; set; }
    }
}