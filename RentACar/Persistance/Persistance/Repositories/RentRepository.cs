﻿using Application.Services.Repositories;
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
    public class RentRepository : EfRepositoryBase<Rent, BaseDbContext>, IRentRepository
    {
        public RentRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
