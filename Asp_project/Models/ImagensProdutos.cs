using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_project.Models
{
    public class ImagensProdutos
    {
        [Key]
        public int id { get; set; }

        public Produto P { get; set; }

        public string imageURL { get; set; }
    }
}
