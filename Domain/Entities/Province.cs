using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Province : BaseEntity, IBaseEntity
    {
        public string Name {get; set;}
        public string Description {get; set;}

        #region Entity Framework Relationship
            public ICollection<PointOfInterest> PointOfInterests {get; set;}

        #endregion
    }
}