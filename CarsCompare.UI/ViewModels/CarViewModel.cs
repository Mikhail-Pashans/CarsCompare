using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarsCompare.UI.ViewModels
{
    public class CarViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("params")]
        public IEnumerable<ParamViewModel> Params { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}