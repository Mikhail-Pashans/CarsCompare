using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCompare.Database.Models.Logger
{
    [Table("log")]
    public class Log : IntPrimaryKeyModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public new int Id { get; set; }
        
        [Column("date")]
        public DateTime Date { get; set; }

        [Column("thread"), MaxLength(255)]
        public string Thread { get; set; }

        [Column("level"), MaxLength(50)]
        public string Level { get; set; }

        [Column("ip_address"), MaxLength(25)]
        public string IpAddress { get; set; }

        [Column("message"), MaxLength(4000)]
        public string Message { get; set; }

        [Column("exception"), MaxLength(2000)]
        public string Exception { get; set; }
    }
}