using System.Collections.Generic;

namespace CarsCompare.Domain.Models
{
    public class ModifyModel : BaseModel
    {
        public ModifyModel()
        {
            Params = new List<ParamModel>();
        }

        public string Name { get; set; }

        public int YearFrom { get; set; }

        public int YearTo { get; set; }

        public ModelModel Model { get; set; }

        public VersionModel Version { get; set; }

        public IEnumerable<ParamModel> Params { get; set; }
    }
}