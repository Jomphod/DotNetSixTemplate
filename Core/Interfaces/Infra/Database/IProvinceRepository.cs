using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Core.Interfaces.Infra.Database
{
    public interface IProvinceRepository : IBaseRepository<Province>
    {
        Task<Province> GetByIdWithPointOfInterestAsync(Guid provinceId);
    }
}