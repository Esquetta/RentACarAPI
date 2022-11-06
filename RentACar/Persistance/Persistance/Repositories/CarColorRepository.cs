using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CarColorRepository : EfRepositoryBase<CarColor, BaseDbContext>,ICarColorRepository
    {
        public CarColorRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
