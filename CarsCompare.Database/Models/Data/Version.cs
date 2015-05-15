using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{
    [Table("bcb_versions")]
    public class Version : BaseModel
    {        
        [Column("model_id")]
        public int? ModelId { get; set; }

        [Column("name"), MaxLength(255)]
        public string Name { get; set; }

        [Column("gen"), MaxLength(255)]
        public string Gen { get; set; }

        [Column("mod"), MaxLength(255)]
        public string Mod { get; set; }

        [JsonIgnore]        
        [ForeignKey("ModelId"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Model Model { get; set; }

        [JsonIgnore]
        [InverseProperty("Version")]
        public virtual ICollection<Modify> Modifies { get; set; }
    }
}