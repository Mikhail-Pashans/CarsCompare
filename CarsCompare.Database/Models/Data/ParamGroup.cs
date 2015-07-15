using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{    
    public class ParamGroup : Base
    {
        [Required, StringLength(255)]
        public string Name { get; set; }

        [JsonIgnore]        
        public virtual ICollection<ParamName> ParamNames { get; set; }

        [JsonIgnore, NotMapped]
        public new int ItemType { get; set; }
    }
}