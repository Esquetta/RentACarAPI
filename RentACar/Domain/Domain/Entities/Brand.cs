using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Brand : Entity
    {

        public string BrandName { get; set; }
        public virtual List<Model> CarModels { get; set; }
        public virtual List<Car> Cars { get; set; }

        public Brand()
        {

        }
        public Brand(int id, string BrandName):this()
        {
            this.Id = id;
            this.BrandName = BrandName;
            
        }
    }
}