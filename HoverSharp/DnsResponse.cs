using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoverSharp.Models;

namespace HoverSharp
{
    public class DnsResponse 
    {
        public bool succeeded { get; set; }
        public Domain[] domains { get; set; }
    }

    public class Entry
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public int ttl { get; set; }
        public bool is_default { get; set; }
        public bool can_revert { get; set; }
    }


}
