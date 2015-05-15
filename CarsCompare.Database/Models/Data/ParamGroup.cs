using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{
    [Table("bcb_param_groups")]
    public class ParamGroup : BaseModel
    {
        [Column("name"), MaxLength(255)]
        public string Name { get; set; }

        [JsonIgnore]
        [InverseProperty("ParamGroup")]
        public virtual ICollection<ParamName> ParamNames { get; set; }

        [JsonIgnore]
        [NotMapped]
        public new int? ItemType { get; set; }
    }
}