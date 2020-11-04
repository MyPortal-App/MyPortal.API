using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortal.Entity.DbEntities
{
     public class Logging
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}
