using CarsCompare.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarsCompare.UI.ViewModels
{
    public class BrandViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("models")]
        public IEnumerable<ModelViewModel> Models { get; set; }

        public static BrandViewModel Map(BrandModel model)
        {
            if (model == null)
                return new BrandViewModel();

            return new BrandViewModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}