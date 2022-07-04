using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomoApp.Business.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

    }

}
