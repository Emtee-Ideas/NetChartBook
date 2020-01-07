using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter03
{
    public class ModelEvents
    {
        public ModelEvents(string msg)
        {
            this.Msg = msg;
        }

        public ModelEvents(List<object> eventList)
        {
            this.EventList = eventList;
        }
        public string Msg { get; private set; }
        public List<object> EventList { get; set; }
    }
}
