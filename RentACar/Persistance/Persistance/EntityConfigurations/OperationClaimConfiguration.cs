using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            OperationClaim[] operationClaims = { new() { Id = 1, Name = "Admin" }, new() { Id = 2, Name = "Moderator" }, new() { Id = 3, Name = "Customer" }, new() { Id = 4, Name = "Manager" }, new() { Id = 5, Name = "Employee" } };
            builder.HasData(operationClaims);
        }
    }
}
