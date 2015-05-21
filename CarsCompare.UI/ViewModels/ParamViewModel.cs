using CarsCompare.Domain.Models;
using Newtonsoft.Json;

namespace CarsCompare.UI.ViewModels
{
    public class ParamViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("modify")]
        public ModifyViewModel Modify { get; set; }

        [JsonProperty("paramName")]
        public ParamNameViewModel ParamName { get; set; }

        public static ParamViewModel Map(ParamModel model)
        {
            if (model == null)
                return new ParamViewModel();

            return new ParamViewModel
            {
                Id = model.Id,
                Value = model.Value
            };
        }
    }
}