using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Entities
{
    public class EntityBase :IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
