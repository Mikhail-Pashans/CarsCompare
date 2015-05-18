using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Data
{
    public class ParamName : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ParamGroupId { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Units { get; set; }

        [JsonIgnore]                
        public virtual ParamGroup ParamGroup { get; set; }

        [JsonIgnore]        
        public virtual ICollection<Param> Params { get; set; }
    }
}