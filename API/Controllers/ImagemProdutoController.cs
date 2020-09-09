using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tolentinos.Domain.Entities;
using Tolentinos.Domain.Interfaces;
using Tolentinos.Infra.Data.Context;
using Tolentinos.Service.Services;
using Tolentinos.Service.Validators;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagemProdutoController : BaseController<ImagemProduto, ImagemProdutoValidator>
    {
        private readonly ImagemProdutoService _service;
        public ImagemProdutoController(ImagemProdutoService service, ILogger<ImagemProduto> logger) : base(service, logger)
        {
            _service = service;
        }

        [NonAction]
        public override ActionResult<ImagemProduto> Post(ImagemProduto model)
        {
            return base.Post(model);
        }

        [HttpPost("{idProduto}")]
        public ActionResult<ImagemProduto> Post([FromRoute]long idProduto, [FromForm]IFormFile imagem){
            var imagemProduto = new ImagemProduto()
            {
                IdProduto = idProduto,
                File = imagem
            };
            return this.Post(imagemProduto);
        }


    }
}
