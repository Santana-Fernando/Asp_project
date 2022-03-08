using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_project.Models
{
    public class AvaliacaoProduto
    {
        [Key]
        public int id_avaliacao { get; set; }
        public int nota { get; set; }
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
        public int Pid_produto { get; set; }
        public Produto P { get; set; }
    }
}
