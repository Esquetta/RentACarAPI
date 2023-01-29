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
    public class GearBoxConfiguration : IEntityTypeConfiguration<GearBox>
    {
        public void Configure(EntityTypeBuilder<GearBox> builder)
        {
            GearBox[] gearBoxes = { new(1, "Manual", 6), new(2, "Automatic", 6), new(3, "Half-Automatic", 6) };
            builder.HasData(gearBoxes);
        }
    }
}
