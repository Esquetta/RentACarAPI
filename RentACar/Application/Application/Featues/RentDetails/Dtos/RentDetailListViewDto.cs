using Application.Featues.Cars.Dtos;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.RentDetails.Dtos
{
    public class RentDetailListViewDto
    {
        public int RentId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Price { get; set; }
        public CarListViewDto Car { get; set; }
        public bool IsFinished { get; set; }
    }
}
