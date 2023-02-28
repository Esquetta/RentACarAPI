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
    public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, BaseDbContext>, IEmailAuthenticatorRepository
    {
        public EmailAuthenticatorRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<ICollection<EmailAuthenticator>> DeleteAllNonVerifiedAsync(User user)
        {
            List<EmailAuthenticator> authentications = Query().Where(x=>x.UserId== user.Id && x.IsVerified==false).ToList();

            await DeleteRangeAsync(authentications);

            return authentications;
        }
    }
}
