using CarsCompare.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarsCompare.UI.ViewModels
{
    public class VersionViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gen")]
        public string Gen { get; set; }

        [JsonProperty("mod")]
        public string Mod { get; set; }

        [JsonProperty("model")]
        public ModelViewModel Model { get; set; }

        [JsonProperty("modifies")]
        public IEnumerable<ModifyViewModel> Modifies { get; set; }

        public static VersionViewModel Map(VersionModel model)
        {
            if (model == null)
                return new VersionViewModel();

            return new VersionViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Gen = model.Gen,
                Mod = model.Mod
            };
        }
    }
}