using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tolentinos.Domain.Entities
{
    public class ImagemProduto : BaseEntity
    {
        public string Url { get; set; }

        public long IdProduto { get; set; }

        public Produto Produto { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
