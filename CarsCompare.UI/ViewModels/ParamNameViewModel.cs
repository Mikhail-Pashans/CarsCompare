using CarsCompare.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarsCompare.UI.ViewModels
{
    public class ParamNameViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("paramGroup")]
        public ParamGroupViewModel ParamGroup { get; set; }

        [JsonProperty("params")]
        public IEnumerable<ParamViewModel> Params { get; set; }

        public static ParamNameViewModel Map(ParamNameModel model)
        {
            if (model == null)
                return new ParamNameViewModel();

            return new ParamNameViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Units = model.Units
            };
        }
    }
}