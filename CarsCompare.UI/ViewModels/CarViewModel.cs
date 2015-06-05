using Newtonsoft.Json;

namespace CarsCompare.UI.ViewModels
{
    public class CarViewModel
    {
        [JsonProperty("brandId")]
        public int BrandId { get; set; }

        [JsonProperty("modelId")]
        public int ModelId { get; set; }

        [JsonProperty("versionId")]
        public int VersionId { get; set; }

        [JsonProperty("modifyId")]
        public int ModifyId { get; set; }
    }
}