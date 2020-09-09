using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;
using Tolentinos.Domain.Interfaces;

namespace Tolentinos.Service.Services
{
    public class MarcaService : BaseService<Marca>
    {
        public MarcaService(IRepository<Marca> repository) : base(repository)
        {
        }
    }
}
