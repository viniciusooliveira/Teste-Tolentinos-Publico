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
    public class CategoriaController : BaseController<Categoria, CategoriaValidator>
    {
        public CategoriaController(CategoriaService service, ILogger<Categoria> logger) : base(service, logger)
        {
        }

        [HttpGet("Menu")]
        public ActionResult<IEnumerable<Categoria>> GetMenu()
        {
            try
            {
                return Ok(_service.GetWhere(m => !m.IdPai.HasValue, "Filhos").OrderBy(m => m.Ordem));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GetMenu {typeof(Categoria)}");
                return StatusCode(500);
            }
        }
    }
}
