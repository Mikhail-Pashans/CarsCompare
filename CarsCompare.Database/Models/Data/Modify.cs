using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{
    [Table("bcb_modify")]
    public class Modify : BaseModel
    {        
        [Column("model_id")]
        public int? ModelId { get; set; }
        
        [Column("version_id")]
        public int? VersionId { get; set; }

        [Column("name"), MaxLength(255)]
        public string Name { get; set; }
        
        [Column("y_from")]
        public int YearFrom { get; set; }

        [Column("y_to")]
        public int YearTo { get; set; }

        [JsonIgnore]        
        [ForeignKey("ModelId"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Model Model { get; set; }

        [JsonIgnore]        
        [ForeignKey("VersionId"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Version Version { get; set; }

        [JsonIgnore]
        [InverseProperty("Modify")]
        public virtual ICollection<Param> Params { get; set; }
    }
}