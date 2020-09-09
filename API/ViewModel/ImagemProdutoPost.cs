using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class ImagemProdutoPost
    {
        public long IdProduto { get; set; }

        public string File { get; set; }
    }
}
