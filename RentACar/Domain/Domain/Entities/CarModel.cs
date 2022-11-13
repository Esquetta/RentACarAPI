using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class CarModel:Entity
    {
        public string ModelName { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        



        public CarModel()
        {

        }
        public CarModel(int id,string modelName,int brandId)
        {
            this.Id= id;
            this.ModelName= modelName;
            this.BrandId= brandId;
        }
    }
}