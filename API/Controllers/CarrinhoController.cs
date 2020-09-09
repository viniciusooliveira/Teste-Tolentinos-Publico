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
    public class CarrinhoController : BaseController<Carrinho, CarrinhoValidator>
    {
        public CarrinhoController(CarrinhoService service, ILogger<Carrinho> logger) : base(service, logger)
        {
        }

        [HttpGet("{id}")]
        public override ActionResult<IEnumerable<Carrinho>> Get(long id)
        {
            try
            {
                Carrinho res = _service.Get(id, "Itens", "Itens.Produto", "Itens.Produto.Categoria", "Itens.Produto.Categoria.Pai", "Itens.Produto.Marca");

                if (res != null && res.Id > 0)
                {
                    return Ok(res);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Get({id}) {typeof(Carrinho)}");
                return StatusCode(500);
            }
        }
    }
}
