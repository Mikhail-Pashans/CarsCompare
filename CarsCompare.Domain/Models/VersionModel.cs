using System.Collections.Generic;

namespace CarsCompare.Domain.Models
{
    public class VersionModel : BaseModel
    {
        public VersionModel()
        {
            Modifies = new List<ModifyModel>();
        }

        public string Name { get; set; }

        public string Gen { get; set; }

        public string Mod { get; set; }

        public ModelModel Model { get; set; }

        public IEnumerable<ModifyModel> Modifies { get; set; }
    }
}