using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Identity
{
    public partial class AspNetUserClaims : IntPrimaryKey
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
        
        [Required, StringLength(128)]
        public string UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        [JsonIgnore]
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}