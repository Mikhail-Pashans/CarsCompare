using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarsCompare.UI.ViewModels
{
    public class DataResultViewModel
    {
        [JsonProperty("brands")]
        public IEnumerable<BrandViewModel> Brands { get; set; }

        [JsonProperty("models")]
        public IEnumerable<ModelViewModel> Models { get; set; }

        [JsonProperty("modifies")]
        public IEnumerable<ModifyViewModel> Modifies { get; set; }

        [JsonProperty("versions")]
        public IEnumerable<VersionViewModel> Versions { get; set; }

        [JsonProperty("params")]
        public IEnumerable<ParamViewModel> Params { get; set; }

        [JsonProperty("paramNames")]
        public IEnumerable<ParamNameViewModel> ParamNames { get; set; }

        [JsonProperty("paramGroups")]
        public IEnumerable<ParamGroupViewModel> ParamGroups { get; set; }
    }
}