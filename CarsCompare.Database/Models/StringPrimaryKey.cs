using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CarsCompare.Domain")]
namespace CarsCompare.Database.Models
{
    public abstract class StringPrimaryKey
    {
        [Key]
        public string Id { get; set; }
    }
}