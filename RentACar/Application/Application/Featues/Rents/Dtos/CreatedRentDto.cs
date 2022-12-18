using Application.Featues.Cars.Dtos;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Rents.Dtos
{
    public class CreatedRentDto
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public string UserName { get; set; }
        public CarListViewDto Car { get; set; }
        public decimal Price { get; set; }
        public bool IsFinished { get; set; }
        
    }
}
