using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestCaliburnMicro.Models;

namespace TestCaliburnMicro
{
  public class AppBootstrapper : BootstrapperBase
  {
    public AppBootstrapper()
    {
      Initialize();
    }

    protected override void OnStartup(object sender, StartupEventArgs e)
    {
      base.OnStartup(sender, e);
      DisplayRootViewFor<MainViewModel>();
    }
  }
}
