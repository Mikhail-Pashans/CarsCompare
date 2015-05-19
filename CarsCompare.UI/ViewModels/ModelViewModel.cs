using CarsCompare.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarsCompare.UI.ViewModels
{
    public class ModelViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("brand")]
        public BrandViewModel Brand { get; set; }

        [JsonProperty("modifies")]
        public IEnumerable<ModifyViewModel> Modifies { get; set; }

        [JsonProperty("versions")]
        public IEnumerable<VersionViewModel> Versions { get; set; }

        public static ModelViewModel Map(ModelModel model)
        {
            if (model == null)
                return new ModelViewModel();

            return new ModelViewModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}