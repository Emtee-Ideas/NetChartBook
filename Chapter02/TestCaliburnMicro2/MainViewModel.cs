using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaliburnMicro2.Models;

namespace TestCaliburnMicro2
{
  [Export(typeof(MainViewModel))]
  public class MainViewModel : PropertyChangedBase, IHandle<ModelEvent>
  {
    private DataModel model;
    private readonly IEventAggregator _events;

    [ImportingConstructor]
    public MainViewModel(CollectionViewModel collectionViewModel,
      IEventAggregator events)
    {
      this._events = events;
      _events.Subscribe(this);

      CollectionViewModel = collectionViewModel;

      model = new DataModel
      {
        Ticker = "IBM",
        Date = Convert.ToDateTime("7/14/2015"),
        PriceOpen = 169.43,
        PriceHigh = 169.54,
        PriceLow = 168.24,
        PriceClose = 168.61
      };
    }

    public CollectionViewModel CollectionViewModel { get; set; }

    public void Handle(ModelEvent message)
    {
      this.MSG = message.Msg;
    }

    private string msg;

    public string MSG
    {
      get { return msg; }
      set 
      { 
        msg = value;
        NotifyOfPropertyChange(() => MSG);
      }
    }


    public DataModel Model
    {
      get { return model; }
      set { model = value; }
    }

		public string Ticker
		{
			get { return Model.Ticker; }
			set
			{
				Model.Ticker = value;
				NotifyOfPropertyChange(() => Ticker);
			}
		}

		public DateTime Date
		{
			get { return Model.Date; }
			set
			{
				Model.Date = value;
				NotifyOfPropertyChange(() => Date);
			}
		}

		public double PriceOpen
		{
			get { return Model.PriceOpen; }
			set
			{
				Model.PriceOpen = value;
				NotifyOfPropertyChange(() => PriceOpen);
			}
		}

		public double PriceHigh
		{
			get { return Model.PriceHigh; }
			set
			{
				Model.PriceHigh = value;
				NotifyOfPropertyChange(() => PriceHigh);
			}
		}

		public double PriceLow
		{
			get { return Model.PriceLow; }
			set
			{
				Model.PriceLow = value;
				NotifyOfPropertyChange(() => PriceLow);
			}
		}

		public double PriceClose
		{
			get { return Model.PriceClose; }
			set
			{
				Model.PriceClose = value;
				NotifyOfPropertyChange(() => PriceClose);
			}
		}

		public void UpdateStock()
		{
			Ticker = "MSFT";
			Date = Convert.ToDateTime("7/14/2015");
			PriceOpen = 45.45;
			PriceHigh = 45.96;
			PriceLow = 45.31;
			PriceClose = 45.62;
		}
	}
}
