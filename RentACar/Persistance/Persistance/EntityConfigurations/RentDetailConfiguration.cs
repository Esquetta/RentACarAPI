using Domain.Entities;
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
    public class RentDetailConfiguration : IEntityTypeConfiguration<RentDetail>
    {
        public void Configure(EntityTypeBuilder<RentDetail> builder)
        {
            builder.Property("Price").HasColumnType("money");
            builder.HasKey(x => new { x.RentId, x.CarId });
        }
    }
}
