using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.RentDetails.Dtos
{
    public class DeletedRentDetailDto
    {
        public int RentId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }
    }
}
