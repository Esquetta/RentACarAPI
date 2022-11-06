using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Photo:Entity
    {
        public int CarId { get; set; }  
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public virtual Car Car { get; set; }

        public Photo()
        {

        }
        public Photo(int Id,string url,bool isMain,string PublicId,int carId):this()
        {
            this.Id = Id;
            this.PublicId = PublicId;
            this.Url = url;
            this.IsMain = isMain;
            this.CarId = carId;
        }
    }
}