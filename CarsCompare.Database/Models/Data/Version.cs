using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{
    public class Version : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModelId { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Gen { get; set; }

        [Required, StringLength(255)]
        public string Mod { get; set; }

        [JsonIgnore]                
        public virtual Model Model { get; set; }

        [JsonIgnore]        
        public virtual ICollection<Modify> Modifies { get; set; }
    }
}