using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ProdutoController : BaseController<Produto, ProdutoValidator>
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service, ILogger<Produto> logger) : base(service, logger)
        {
            _service = service;
        }

        [HttpGet("All")]
        public override ActionResult<IEnumerable<Produto>> Get()
        {
            return base.Get();
        }

        /// <summary>
        /// Listagem paginada e ordenada de produtos
        /// </summary>
        /// <param name="p">Número da página</param>
        /// <param name="c">Quantaidade de registros por página</param>
        /// <param name="q">Texto a ser buscado no nome e descrição</param>
        /// <param name="idMarca">Id da Marca </param>
        /// <param name="idCategoria">Id da Categoria</param>
        /// <param name="o">Campo a ser ordenado, pode ser qualquer campo do Produto</param>
        /// <param name="oDescending">Tipo de ordenação. FALSE = Crescente | TRUE = Decrescente</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get(
            [FromQuery] int p = 1,
            [FromQuery] int c = 50,
            [FromQuery] string q = null,
            [FromQuery] long? idMarca = null,
            [FromQuery] long? idCategoria = null,
            [FromQuery] string o = "Nome",
            [FromQuery] bool oDescending = false)
        {
            try
            {
                var res = _service.Get(p, c, q, idMarca, idCategoria, o, oDescending, out long total);

                return Ok(new
                {
                    Produtos = res,
                    RegisterCount = total,
                    PageCount = Decimal.Ceiling(total / c)
                });
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"Get ({p}, {c}, {q}, {idMarca}, {idCategoria}, {o}, {oDescending}) {typeof(Produto)}");
                return StatusCode(500);
            }
        }
    }
}
