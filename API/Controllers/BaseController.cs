using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tolentinos.Domain.Entities;
using Tolentinos.Domain.Interfaces;

namespace API.Controllers
{
    public class BaseController<T, V> : Controller where T : BaseEntity where V : AbstractValidator<T>
    {
        protected IService<T> _service;
        protected ILogger _logger;
        public BaseController(IService<T> service, ILogger<T> logger) {
            _service = service;
            _logger = logger;
        }


        [HttpGet]
        public virtual ActionResult<IEnumerable<T>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Get {typeof(T)}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public virtual ActionResult<IEnumerable<T>> Get(long id)
        {
            try
            {
                T res = _service.Get(id);

                if(res != null && res.Id > 0)
                {
                    return Ok(res);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Get({id}) {typeof(T)}");
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public virtual IActionResult Put(long id, T model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.Put<V>(model);
                return Ok();
            }
            catch (ValidationException ve)
            {
                return BadRequest(new { ve.Message, ve.Errors });
            }
            catch (DbUpdateConcurrencyException e)
            {
                if(_service.Get(id) == null)
                {
                    return NotFound();
                }
                _logger.LogError(e, $"Put({id}) {typeof(T)}");
                return StatusCode(500);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Put({id}) {typeof(T)}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public virtual ActionResult<T> Post(T model)
        {

            try
            {
                model = _service.Post<V>(model);
                return CreatedAtAction("Get", new { id = model.Id }, model);

            }
            catch (ValidationException ve) {
                return BadRequest(new { ve.Message,  ve.Errors});
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Post {typeof(T)}");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public virtual ActionResult<T> Delete(long id)
        {
            try
            {
                T model = _service.Get(id);
                if (model == null)
                {
                    return NotFound();
                }

                _service.Remove(model.Id);

                return Ok(model);
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"Delete({id}) {typeof(T)}");
                return StatusCode(500);
            }
            
        }


    }
}
