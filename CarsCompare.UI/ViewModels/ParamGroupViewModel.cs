using CarsCompare.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarsCompare.UI.ViewModels
{
    public class ParamGroupViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("paramNames")]
        public IEnumerable<ParamNameViewModel> ParamNames { get; set; }

        public static ParamGroupViewModel Map(ParamGroupModel model)
        {
            if (model == null)
                return new ParamGroupViewModel();

            return new ParamGroupViewModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}