using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Cars.Dtos
{
    public class DeletedCarDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int? CarModelId { get; set; }
        public short ProductionYear { get; set; }
        public string? Plate { get; set; }
        public double Price { get; set; }
        public int HorsePower { get; set; }
        public int CarColorId { get; set; }
        public int GearBoxId { get; set; }
        public int FuelId { get; set; }
        public int Miles { get; set; }
        public string Description { get; set; }
        public CarState CarState { get; set; }
    }
}
