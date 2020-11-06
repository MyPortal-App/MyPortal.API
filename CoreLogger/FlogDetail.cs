using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flogging.Core
{
    public class FlogDetail
    {
        public FlogDetail()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
        public string Message { get; set; }
        //WHERE
        public string Application { get; set; }
        public string Layer { get; set; }
        public string Location { get; set; }
        public string Hostname { get; set; }
        //wHO
        public string UserId { get; set; }
        public string UserName { get; set; }   
        //EVERYTHING ELSE
        public long? EllapsedMilliseconds { get; set; } //only for performance entried
        public Exception Exception { get; set; } //the exception for error logging
        public string CorrelationId { get; set; } // excpetion shielding from server to client
        public Dictionary<string, object> AdditionalInfo { get; set; } // catch-all for anything 
    }
}
