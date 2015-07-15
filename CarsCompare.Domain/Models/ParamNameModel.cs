using System.Collections.Generic;

namespace CarsCompare.Domain.Models
{
    public class ParamNameModel : BaseModel
    {
        public ParamNameModel()
        {
            Params = new List<ParamModel>();
        }

        public string Name { get; set; }

        public string Units { get; set; }

        public ParamGroupModel ParamGroup { get; set; }

        public IEnumerable<ParamModel> Params { get; set; }
    }
}