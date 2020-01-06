using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Models
{
    public class RightWayViewModel : INotifyPropertyChanged
    {
		private DataModel model;

		public RightWayViewModel()
		{
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
				OnPropertyChanged("Ticker");
			}
		}

		public DateTime Date
		{
			get { return Model.Date; }
			set
			{
				Model.Date = value;
				OnPropertyChanged("Date");
			}
		}

		public double PriceOpen
		{
			get { return Model.PriceOpen; }
			set
			{
				Model.PriceOpen = value;
				OnPropertyChanged("PriceOpen");
			}
		}

		public double PriceHigh
		{
			get { return Model.PriceHigh; }
			set
			{
				Model.PriceHigh = value;
				OnPropertyChanged("PriceHigh");
			}
		}

		public double PriceLow
		{
			get { return Model.PriceLow; }
			set
			{
				Model.PriceLow = value;
				OnPropertyChanged("PriceLow");
			}
		}

		public double PriceClose
		{
			get { return Model.PriceClose; }
			set
			{
				Model.PriceClose = value;
				OnPropertyChanged("PriceClose");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
