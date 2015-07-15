using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsCompare.Database.Models.Data
{
    public class Brand : Base
    {
        [Required, StringLength(255)]
        public string Name { get; set; }

        [JsonIgnore]        
        public virtual ICollection<Model> Models { get; set; }
    }
}