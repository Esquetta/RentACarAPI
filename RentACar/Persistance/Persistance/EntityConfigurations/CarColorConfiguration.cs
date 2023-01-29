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
    public class CarColorConfiguration : IEntityTypeConfiguration<CarColor>
    {
        public void Configure(EntityTypeBuilder<CarColor> builder)
        {
            CarColor[] carColors = { new(1, "Blue"), new(2, "Red"), new(3, "Yellow"), new(4, "White"), new(5, "Black"), new(6, "Green"), new(7, "Metalic Grey"), new(8, "Midnight Purple"), new(9, "Orange") };
            builder.HasData(carColors);
        }
    }
}
