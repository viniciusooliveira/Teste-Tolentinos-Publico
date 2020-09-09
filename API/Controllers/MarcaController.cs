﻿using System;
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
    public class MarcaController : BaseController<Marca, MarcaValidator>
    {
        public MarcaController(MarcaService service, ILogger<Marca> logger) : base(service, logger)
        {
        }
    }
}
