using System;

namespace CarsCompare.Domain.Models
{
    public class LogModel : BaseModel
    {
        public DateTime Date { get; set; }

        public string Thread { get; set; }

        public string Level { get; set; }

        public string IpAddress { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }
    }
}