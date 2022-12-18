using Application.Featues.Photos.Dtos;
using Domain.Entities;
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
        public DateTime ProductionDate { get; set; }
        public decimal Price { get; set; }
        public int HorsePower { get; set; }
        public string CarColor { get; set; }
        public string GearBox { get; set; }
        public string Fuel { get; set; }
        public int Miles { get; set; }
        public string Description { get; set; }
        public bool For_Rent { get; set; }
        public List<PhotoListViewDto> Photos { get; set; }
    }
}
