using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class GearBoxRepository : EfRepositoryBase<GearBox, BaseDbContext>, IGearBoxRepository
    {
        public GearBoxRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
