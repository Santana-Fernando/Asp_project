using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_project.Models
{
    public class AvaliacaoLoja
    {
        [Key]
        public int id_avaliacao { get; set; }
        public int nota { get; set; }
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
        public int Lid_loja { get; set; }
        public Loja L { get; set; }
    }
}
