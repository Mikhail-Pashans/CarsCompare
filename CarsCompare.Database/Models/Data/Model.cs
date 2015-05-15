using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{
    [Table("bcb_models")]
    public class Model : BaseModel
    {        
        [Column("brand_id")]
        public int? BrandId { get; set; }

        [Column("name"), MaxLength(255)]
        public string Name { get; set; }
        
        [JsonIgnore]        
        [ForeignKey("BrandId"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Brand Brand { get; set; }

        [JsonIgnore]
        [InverseProperty("Model")]
        public virtual ICollection<Version> Versions { get; set; }

        [JsonIgnore]
        [InverseProperty("Model")]
        public virtual ICollection<Modify> Modifies { get; set; }
    }
}