using Application.Featues.Photos.Dtos;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Cars.Dtos
{
    public class CarListViewDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CarModelName { get; set; }
        public short ProductionYear { get; set; }
        public string? Plate { get; set; }
        public double Price { get; set; }
        public int HorsePower { get; set; }
        public string CarColor { get; set; }
        public string GearBox { get; set; }
        public string Fuel { get; set; }
        public int Miles { get; set; }
        public string Description { get; set; }
        public CarState CarState { get; set; }
        public List<PhotoListViewDto> Photos { get; set; }
    }
}
