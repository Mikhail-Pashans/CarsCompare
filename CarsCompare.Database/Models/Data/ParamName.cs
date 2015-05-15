using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{
    [Table("bcb_param_names")]
    public class ParamName : BaseModel
    {        
        [Column("group_id")]
        public int? GroupId { get; set; }

        [Column("name"), MaxLength(255)]
        public string Name { get; set; }

        [Column("units"), MaxLength(255)]
        public string Units { get; set; }

        [JsonIgnore]        
        [ForeignKey("GroupId"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual ParamGroup ParamGroup { get; set; }

        [JsonIgnore]
        [InverseProperty("ParamName")]
        public virtual ICollection<Param> Params { get; set; }
    }
}