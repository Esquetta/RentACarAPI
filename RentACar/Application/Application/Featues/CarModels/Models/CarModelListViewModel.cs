using Application.Featues.Brands.Dtos;
using Application.Featues.CarModels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarModels.Models
{
    public class CarModelListViewModel
    {
        public List<CarModelListViewDto> Items { get; set; }
    }
}
