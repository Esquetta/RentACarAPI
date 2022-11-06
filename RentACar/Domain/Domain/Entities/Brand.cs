using Core.Persistence.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Brand : Entity
    {

        public string BrandName { get; set; }
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