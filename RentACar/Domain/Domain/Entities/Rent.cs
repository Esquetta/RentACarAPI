using Core.Persistence.Repositories;
using Core.Security.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Rent:Entity
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public int userId { get; set; }
        public virtual User Customer { get; set; }
        public bool IsFinished { get; set; }

        public Rent()
        {

        }
        public Rent(int Id,int customerId,DateTime dateOfIssue,DateTime returnDate,bool isFinised):this()
        {
            this.Id = Id;
            this.userId = customerId;
            this.DateOfIssue= dateOfIssue;
            this.ReturnDate = returnDate;
            this.IsFinished = isFinised;
        }

    }
}