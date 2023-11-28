using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookHub.Models
{
    public class LivroModel
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Genero { get; set; }
        public string NomeAutor { get; set; }
        public int IdAnotacao { get; set; }

    }
}