using System;
using System.Collections.Generic;
using System.Text;

namespace Tolentinos.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual long Id { get; set; }
    }
}
