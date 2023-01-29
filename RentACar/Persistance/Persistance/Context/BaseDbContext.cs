using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class BaseDbContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarColor> CarColors { get; set; }
        public DbSet<GearBox> GearBoxes { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<RentDetail> RentDetails { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
        public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }

        protected IConfiguration Configuration { get; set; }

        

        public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
        {
            configuration = Configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACar")));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Refactor
            modelBuilder.Entity<Car>().HasOne(x=>x.CarModel).WithMany(x=>x.Cars).OnDelete(DeleteBehavior.Restrict);    
            Fuel[] fuels ={new(1,"Gasoline"),new(2,"Motorine"),new(3,"Electrical")};
            modelBuilder.Entity<Fuel>().HasData(fuels);

            CarColor[] carColors = { new(1, "Blue"), new(2, "Red"), new(3, "Yellow"),new(4,"White"),new(5,"Black"), new(6,"Green"), new(7,"Metalic Grey"), new(8,"Midnight Purple"), new(9,"Orange") };
            modelBuilder.Entity<CarColor>().HasData(carColors);

            GearBox[] gearBoxes = { new(1,"Manual",6), new(2,"Automatic",6), new(3,"Half-Automatic",6) };
            modelBuilder.Entity<GearBox>().HasData(gearBoxes);

            Brand[] brands = { new(1, "Audi"), new(2, "Ford"), new(3, "Nissan"),new(4,"Toyata"), new(5,"BMW"), new(6,"Mercedes"), new(7,"Porche"), new(8,"Doge"),new(9,"Ferrari"), new(10,"Lamborghini") };
            modelBuilder.Entity<Brand>().HasData(brands);


            CarModel[] carModels = { new(1, "A4", 1), new(2, "Focus RS", 2), new(3, "GTR", 3), new(4, "Supra", 4), new(5, "M5", 5), new(6, "AMG GTR", 6), new(7, "GT3", 7), new(8, "Charger", 8) };
            modelBuilder.Entity<CarModel>().HasData(carModels);

            OperationClaim[] operationClaims = { new() {Id=1,Name="Admin"},new() { Id = 2, Name ="Moderator" },new() { Id = 3, Name ="Customer" }, new() { Id = 4, Name = "Manager" }, new() { Id = 5, Name = "Employee" } };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaims);

            modelBuilder.Entity<Car>(x => {
                x.Property("Price").HasColumnType("money");
            });
            modelBuilder.Entity<RentDetail>(x => {
                x.Property("Price").HasColumnType("money");
            });
            modelBuilder.Entity<RentDetail>().HasKey(x =>new { x.RentId,x.CarId});


            




        }
    }
}
