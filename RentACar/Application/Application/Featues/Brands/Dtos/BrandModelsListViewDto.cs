using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Brands.Dtos
{
    public class BrandModelsListViewDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public List<CarModelListViewDto> CarModels { get; set; }
    }
    public class CarModelListViewDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
    }
}
