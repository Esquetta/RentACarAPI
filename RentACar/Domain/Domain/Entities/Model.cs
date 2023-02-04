using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Model:Entity
    {
        public string ModelName { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public List<Car> Cars { get; set; }





        public Model()
        {

        }
        public Model(int id,string modelName,int brandId)
        {
            this.Id= id;
            this.ModelName= modelName;
            this.BrandId= brandId;
        }
    }
}