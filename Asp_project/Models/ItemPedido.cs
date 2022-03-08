using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_project.Models
{
    public class ItemPedido
    {
        [Key]
        public int id_item_pedido { get; set; }
        public int quantidade { get; set; }
        public decimal valor { get; set; }
        public int Proid_produto { get; set; }
        public Produto Pro { get; set; }
        public int Peid_pedido { get; set; }
        public Pedido Pe { get; set; }
    }
}
