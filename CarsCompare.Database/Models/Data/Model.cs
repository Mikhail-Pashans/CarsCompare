using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{    
    public class Model : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BrandId { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }
        
        [JsonIgnore]                
        public virtual Brand Brand { get; set; }

        [JsonIgnore]
        public virtual ICollection<Modify> Modifies { get; set; }
        
        [JsonIgnore]        
        public virtual ICollection<Version> Versions { get; set; }        
    }
}