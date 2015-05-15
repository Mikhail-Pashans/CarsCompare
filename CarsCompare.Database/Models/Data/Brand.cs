using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{
    [Table("bcb_brands")]
    public class Brand : BaseModel
    {
        [Column("name"), MaxLength(255)]
        public string Name { get; set; }

        [JsonIgnore]
        [InverseProperty("Brand")]
        public virtual ICollection<Model> Models { get; set; }
    }
}