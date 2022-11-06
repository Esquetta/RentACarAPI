

namespace Domain.Entities
{
    public class RentDetail
    {
        public int RentId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }
        public virtual Car Car { get; set; }
        public virtual Rent Rent { get; set; }

        public RentDetail()
        {

        }
        public RentDetail(int rentId,int carId,decimal price)
        {
            this.RentId= rentId;
            this.CarId = carId;
            this.Price = price;
        }
    }
}