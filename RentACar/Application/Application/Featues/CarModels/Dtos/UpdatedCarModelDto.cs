using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarModels.Dtos
{
    public class UpdatedCarModelDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int BrandId { get; set; }
    }
}
