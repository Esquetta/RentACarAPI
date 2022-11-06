

using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class GearBox:Entity
    {
        public string GearType { get; set; }
        public int Speed { get; set; }

        public virtual List<Car> Cars { get; set; }

        public GearBox()
        {

        }
        public GearBox(int id,string gearType,int speed):this()
        {
            this.Id = id;
            this.GearType = gearType;
            this.Speed = speed;
        }
    }
}