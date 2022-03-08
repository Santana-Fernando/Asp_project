using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_project.Models
{
    public class Pedido
    {
        [Key]
        public int id_pedido { get; set; }

        public DateTime data_pedido { get; set; }

        [Display(Name = "Data final do pedido")]
        [Required(ErrorMessage = "Informe a previsão de conclusão do pedido")]
        public DateTime data_final { get; set; }

        [Display(Name = "Status do Pedido")]
        public string status { get; set; }

        public int Uid_usuario { get; set; }
        public Usuario U { get; set; }

        public int Lid_loja { get; set; }
        public Loja L { get; set; }

        public decimal valor { get; set; }
    }
}
