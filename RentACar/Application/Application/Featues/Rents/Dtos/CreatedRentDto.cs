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
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public int userId { get; set; }
        public bool IsFinished { get; set; }

    }
}
