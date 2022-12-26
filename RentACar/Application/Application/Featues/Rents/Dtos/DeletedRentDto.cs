using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Rents.Dtos
{
    public class DeletedRentDto
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public int UserId { get; set; }
        public bool IsFinished { get; set; }
    }
}
