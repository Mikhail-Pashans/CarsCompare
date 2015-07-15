using CarsCompare.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarsCompare.UI.ViewModels
{
    public class ModifyViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("yearFrom")]
        public int YearFrom { get; set; }

        [JsonProperty("yearTo")]
        public int YearTo { get; set; }

        [JsonProperty("model")]
        public ModelViewModel Model { get; set; }

        [JsonProperty("version")]
        public VersionViewModel Version { get; set; }

        [JsonProperty("params")]
        public IEnumerable<ParamViewModel> Params { get; set; }

        public static ModifyViewModel Map(ModifyModel model)
        {
            if (model == null)
                return new ModifyViewModel();

            return new ModifyViewModel
            {
                Id = model.Id,
                Name = model.Name,
                YearFrom = model.YearFrom,
                YearTo = model.YearTo
            };
        }
    }
}