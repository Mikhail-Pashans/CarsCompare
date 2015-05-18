using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{
    public class Param : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModifyId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ParamNameId { get; set; }

        [Required, StringLength(255)]
        public string Value { get; set; }

        [JsonIgnore]        
        public virtual Modify Modify { get; set; }

        [JsonIgnore]        
        public virtual ParamName ParamName { get; set; }
    }
}