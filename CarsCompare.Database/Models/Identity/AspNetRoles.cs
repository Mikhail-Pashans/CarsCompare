using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsCompare.Database.Models.Identity
{
    public partial class AspNetRoles : StringPrimaryKey
    {
        [Required, StringLength(128)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}