using System.Collections.Generic;

namespace CarsCompare.Domain.Models
{
    public class ModelModel : BaseModel
    {
        public ModelModel()
        {
            Modifies = new List<ModifyModel>();

            Versions = new List<VersionModel>();
        }

        public string Name { get; set; }

        public BrandModel Brand { get; set; }

        public IEnumerable<ModifyModel> Modifies { get; set; }

        public IEnumerable<VersionModel> Versions { get; set; }
    }
}