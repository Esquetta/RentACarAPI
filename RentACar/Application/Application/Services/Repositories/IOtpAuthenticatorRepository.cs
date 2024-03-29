﻿using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IOtpAuthenticatorRepository:IRepository<OtpAuthenticator>,IAsyncRepository<OtpAuthenticator>
    {
        Task<ICollection<OtpAuthenticator>> DeleteAllNonVerifiedAsync(User user);
    }
}
