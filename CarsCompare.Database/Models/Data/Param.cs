using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{
    [Table("bcb_params")]
    public class Param : BaseModel
    {        
        [Column("modify_id")]
        public int? ModifyId { get; set; }
        
        [Column("param_id")]
        public int? ParamId { get; set; }

        [Column("value"), MaxLength(255)]
        public string Value { get; set; }

        [JsonIgnore]        
        [ForeignKey("ModifyId"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Modify Modify { get; set; }

        [JsonIgnore]        
        [ForeignKey("ParamId"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual ParamName ParamName { get; set; }
    }
}