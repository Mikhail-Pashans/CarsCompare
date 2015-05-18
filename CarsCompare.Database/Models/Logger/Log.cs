using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Logger
{
    public class Log : IntPrimaryKey
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
                
        public DateTime Date { get; set; }

        [StringLength(255)]
        public string Thread { get; set; }

        [StringLength(50)]
        public string Level { get; set; }

        [StringLength(25)]
        public string IpAddress { get; set; }

        [StringLength(4000)]
        public string Message { get; set; }

        [StringLength(2000)]
        public string Exception { get; set; }
    }
}