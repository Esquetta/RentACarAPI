using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Cars.Dtos
{
    public class CreatedCarDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int? CarModelId { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal Price { get; set; }
        public int HorsePower { get; set; }
        public int CarColorId { get; set; }
        public int GearBoxId { get; set; }
        public int FuelId { get; set; }
        public int Miles { get; set; }
        public string Description { get; set; }
        public bool For_Rent { get; set; }
    }
}
