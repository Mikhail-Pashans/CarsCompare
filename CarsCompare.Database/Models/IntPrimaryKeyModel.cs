using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CarsCompare.Domain")]
namespace CarsCompare.Database.Models
{
    public abstract class IntPrimaryKeyModel
    {
        public int Id { get; set; }
    }
}