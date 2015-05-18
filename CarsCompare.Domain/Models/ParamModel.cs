namespace CarsCompare.Domain.Models
{
    public class ParamModel : BaseModel
    {
        public string Value { get; set; }

        public ModifyModel Modify { get; set; }

        public ParamNameModel ParamName { get; set; }
    }
}