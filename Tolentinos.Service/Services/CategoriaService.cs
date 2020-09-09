using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;
using Tolentinos.Domain.Interfaces;

namespace Tolentinos.Service.Services
{
    public class CategoriaService : BaseService<Categoria>
    {
        public CategoriaService(IRepository<Categoria> repository) : base(repository)
        {
        }
    }
}
