using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, BaseDbContext>, IOtpAuthenticatorRepository
    {
        public OtpAuthenticatorRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<ICollection<OtpAuthenticator>> DeleteAllNonVerifiedAsync(User user)
        {
           var nonVerifieds= Query().Where(x => x.IsVerified == false && x.UserId == user.Id).ToList();
           await DeleteRangeAsync(nonVerifieds);

            return nonVerifieds;
        }
    }
}
