using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{
    public class Modify : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModelId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VersionId { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }
        
        public int YearFrom { get; set; }

        public int YearTo { get; set; }

        [JsonIgnore]                
        public virtual Model Model { get; set; }

        [JsonIgnore]                
        public virtual Version Version { get; set; }

        [JsonIgnore]        
        public virtual ICollection<Param> Params { get; set; }
    }
}