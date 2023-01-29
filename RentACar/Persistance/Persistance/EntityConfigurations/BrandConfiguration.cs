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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            Brand[] brands = { new(1, "Audi"), new(2, "Ford"), new(3, "Nissan"), new(4, "Toyata"), new(5, "BMW"), new(6, "Mercedes"), new(7, "Porche"), new(8, "Doge"), new(9, "Ferrari"), new(10, "Lamborghini") };
            builder.HasData(brands);
        }
    }
}
