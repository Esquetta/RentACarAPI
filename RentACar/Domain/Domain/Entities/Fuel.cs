using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Fuel:Entity
    {
        public string FuelType { get; set; }

        public virtual List<Car> Cars { get; set; }

        public Fuel()
        {

        }
        public Fuel(int id,string fuelType):this()
        {
            this.Id = id;
            this.FuelType = fuelType;   
        }
                
    }
}