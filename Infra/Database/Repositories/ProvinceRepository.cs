using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.Database;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<Province> GetByIdWithPointOfInterestAsync(Guid provinceId){
            return await base._context.Provinces
                        .Include(c => c.PointOfInterests)
                        .FirstOrDefaultAsync(c => c.Id == provinceId);
        }
    }
}