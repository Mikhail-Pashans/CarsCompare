using System.Collections.Generic;

namespace CarsCompare.Domain.Models
{
    public class ParamGroupModel : BaseModel
    {
        public string Name { get; set; }

        public IEnumerable<ParamNameModel> ParamNames { get; set; }
    }
}