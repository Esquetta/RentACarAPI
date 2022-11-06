
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class CarColor:Entity
    {
        public string Color { get; set; }

        public CarColor()
        {

        }
        public CarColor(int id,string Color):this()
        {
            this.Id = id;
            this.Color = Color;
        }
    }
}