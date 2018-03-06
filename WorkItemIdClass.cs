using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedClientConsoleAppSample
{

    public class WorkItemIdClass
    {
        public int count { get; set; }
        public ValueWorkItemIdClass[] value { get; set; }
    }

    public class ValueWorkItemIdClass
    {
        public string id { get; set; }
        public string url { get; set; }
    }

}
