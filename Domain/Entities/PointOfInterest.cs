using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PointOfInterest : BaseEntity, IBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        #region Entity Framework Relationship
            public Province Province { get; set; }

            public Guid ProvinceId { get; set; }

        #endregion
    }
}