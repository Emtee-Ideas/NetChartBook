using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaliburnMicro2
{
  public class ModelEvent
  {
    public ModelEvent(string msg)
    {
      this.Msg = msg;
    }
    public string Msg { get; private set; }
  }
}
