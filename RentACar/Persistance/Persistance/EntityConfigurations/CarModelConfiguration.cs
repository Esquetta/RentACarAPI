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
    public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            CarModel[] carModels = { new(1, "A4", 1), new(2, "Focus RS", 2), new(3, "GTR", 3), new(4, "Supra", 4), new(5, "M5", 5), new(6, "AMG GTR", 6), new(7, "GT3", 7), new(8, "Charger", 8) };
            builder.HasData(carModels);
        }
    }
}
