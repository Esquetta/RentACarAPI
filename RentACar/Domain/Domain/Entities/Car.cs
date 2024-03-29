﻿using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities
{
    public class Car : Entity
    {
        public int BrandId { get; set; }
        public int? CarModelId { get; set; }
        public short ProductionYear { get; set; }
        public double Price { get; set; }
        public int HorsePower { get; set; }
        public int CarColorId { get; set; }
        public int GearBoxId { get; set; }
        public int FuelId { get; set; }
        public int Miles { get; set; }
        public string Description { get; set; }
        public string? Plate { get; set; }
        public CarState CarState { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public virtual List<RentDetail> RendDetails { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual CarColor CarColor { get; set; }
        public virtual GearBox GearBox { get; set; }
        public virtual Fuel Fuel { get; set; }
        public virtual Model CarModel { get; set; }


        public Car()
        {
            
        }
        public Car(int Id, int brandId,int carModelId,short ProductionYear, double price, int horsePower, int carColorId, int gearBoxId, int fuelId, int miles, string Description,CarState carState) : this()
        {
            this.Id = Id;
            this.BrandId = brandId;
            this.ProductionYear = ProductionYear;
            this.Price = price;
            this.HorsePower = horsePower;
            this.CarColorId = carColorId;
            this.GearBoxId = gearBoxId;
            this.FuelId = fuelId;
            this.Miles = miles;
            this.Description = Description;
            this.CarState= carState;
            this.CarModelId = carModelId;

        }
    }
}
