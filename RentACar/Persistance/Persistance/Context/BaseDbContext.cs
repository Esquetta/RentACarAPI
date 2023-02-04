using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class BaseDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> CarModels { get; set; }
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



        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            configuration = Configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACar")));

        }
        //public override async  Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    IEnumerable<EntityEntry<Entity>> datas = ChangeTracker.Entries<Entity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        //    foreach (var item in datas)
        //    {
        //        switch (item.State)
        //        {

        //            case EntityState.Modified:
        //                item.Entity.UpdatedDate = DateTime.Now;
        //                break;
        //            case EntityState.Added: item.Entity.CreatedDate = DateTime.Now; break;
        //        }
        //    }
        //    return await  base.SaveChangesAsync(cancellationToken);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
