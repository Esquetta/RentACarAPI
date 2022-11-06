using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : Entity
    {
        public int BrandId { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal Price { get; set; }
        public int HorsePower { get; set; }
        public int CarColorId { get; set; }
        public int GearBoxId { get; set; }
        public int FuelId { get; set; }
        public int Miles { get; set; }
        public string Description { get; set; }
        public bool For_Rent { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public virtual List<RentDetail> RendDetails { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual CarColor CarColor { get; set; }
        public virtual GearBox GearBox { get; set; }
        public virtual Fuel Fuel { get; set; }

        public Car()
        {
            
        }
        public Car(int Id, int brandId, string model, DateTime productionDate, decimal price, int horsePower, int carColorId, int gearBoxId, int fuelId, int miles, string Description, bool for_rent) : this()
        {
            this.Id = Id;
            this.BrandId = brandId;
            this.Model = model;
            this.ProductionDate = productionDate;
            this.Price = price;
            this.HorsePower = horsePower;
            this.CarColorId = carColorId;
            this.GearBoxId = gearBoxId;
            this.FuelId = fuelId;
            this.Miles = miles;
            this.Description = Description;
            this.For_Rent = for_rent;

        }
    }
}
