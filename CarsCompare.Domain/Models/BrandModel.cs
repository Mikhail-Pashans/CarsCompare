using System.Collections.Generic;

namespace CarsCompare.Domain.Models
{
    public class BrandModel : BaseModel
    {
        public BrandModel()
        {
            Models = new List<ModelModel>();
        }

        public string Name { get; set; }

        private IEnumerable<ModelModel> Models { get; set; }
    }
}