﻿using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IEmailAuthenticatorRepository:IRepository<EmailAuthenticator>,IAsyncRepository<EmailAuthenticator>
    {
        Task<ICollection<EmailAuthenticator>> DeleteAllNonVerifiedAsync(User user);
    }
}
