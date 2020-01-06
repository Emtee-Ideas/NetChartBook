using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmBase;

namespace Chapter02.Models
{
    public class MvvmBaseViewModel : PropertyChangedBase
    {
		private DataModel model;

		public MvvmBaseViewModel()
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
				OnPropertyChanged();
			}
		}

		public DateTime Date
		{
			get { return Model.Date; }
			set
			{
				Model.Date = value;
				OnPropertyChanged();
			}
		}

		public double PriceOpen
		{
			get { return Model.PriceOpen; }
			set
			{
				Model.PriceOpen = value;
				OnPropertyChanged();
			}
		}

		public double PriceHigh
		{
			get { return Model.PriceHigh; }
			set
			{
				Model.PriceHigh = value;
				OnPropertyChanged();
			}
		}

		public double PriceLow
		{
			get { return Model.PriceLow; }
			set
			{
				Model.PriceLow = value;
				OnPropertyChanged();
			}
		}

		public double PriceClose
		{
			get { return Model.PriceClose; }
			set
			{
				Model.PriceClose = value;
				OnPropertyChanged();
			}
		}

		private void UpdateStockExecute()
		{
			Ticker = "MSFT";
			Date = Convert.ToDateTime("7/14/2015");
			PriceOpen = 45.45;
			PriceHigh = 45.96;
			PriceLow = 45.31;
			PriceClose = 45.62;
		}

		private bool CanUpdateStockExecute()
		{
			return true;
		}

		public ICommand UpdateStock
		{
			get { return new CommandBase(UpdateStockExecute, CanUpdateStockExecute); }
		}
	}
}
