using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<ICollection<RefreshToken>> GetAllOldActiveRefreshTokenAsync(User user, int ttl)
        {
            return await Query().Where(x => x.UserId == user.Id &&
            x.Revoked == null && x.Expires > DateTime.UtcNow &&
            x.CreatedDate.AddMinutes(ttl)<DateTime.UtcNow).ToListAsync();
        }
    }
}
