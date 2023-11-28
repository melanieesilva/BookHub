using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookHub.Models
{
    public class AnotacaoModel
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Categoria { get; set; }
        public string Cor { get; set; }
        public DateTimeOffset DataPulicacao { get; set; }
    }
}