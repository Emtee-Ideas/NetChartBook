using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter03
{
    [Export(typeof(IMain))]
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive, IMain, IHandle<ModelEvents>
    {
        private readonly IEventAggregator _events;

        [ImportingConstructor]
        public MainViewModel([ImportMany]IEnumerable<IScreen> screens, IEventAggregator events)
        {
            var sc = screens.OrderBy(item => item.DisplayName);
            Items.AddRange(sc);
            this._events = events;
            _events.Subscribe(this);
            DisplayName = "Chapter 3";
        }

        public void Handle(ModelEvents message)
        {
            List<object> lst = message.EventList;
            StatusText = lst[0].ToString();
            if (lst.Count > 1)
            {
                ProgressMin = Convert.ToInt32(lst[1]);
                ProgressMax = Convert.ToInt32(lst[2]);
                ProgressValue = Convert.ToInt32(lst[3]);
            }
        }

        private int progressMin;
        public int ProgressMin
        {
            get { return progressMin; }
            set 
            { 
                progressMin = value;
                NotifyOfPropertyChange(() => ProgressMin);
            }
        }

        private int progressMax;
        public int ProgressMax
        {
            get { return progressMax; }
            set
            {
                progressMax = value;
                NotifyOfPropertyChange(() => ProgressMax);
            }
        }

        private int progressValue;
        public int ProgressValue
        {
            get { return progressValue; }
            set
            {
                progressValue = value;
                NotifyOfPropertyChange(() => ProgressValue);
            }
        }

        private string statusText;
        public string StatusText
        {
            get { return statusText; }
            set
            {
                statusText = value;
                NotifyOfPropertyChange(() => StatusText);
            }
        }
    }
}
