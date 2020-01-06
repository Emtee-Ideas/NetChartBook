using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaliburnMicro.Models
{
	public class DataModel
	{
		private string ticker;

		public string Ticker
		{
			get { return ticker; }
			set { ticker = value; }
		}

		private DateTime date;

		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		private double priceOpen;

		public double PriceOpen
		{
			get { return priceOpen; }
			set { priceOpen = value; }
		}

		private double priceHigh;

		public double PriceHigh
		{
			get { return priceHigh; }
			set { priceHigh = value; }
		}

		private double priceLow;

		public double PriceLow
		{
			get { return priceLow; }
			set { priceLow = value; }
		}

		private double priceClose;

		public double PriceClose
		{
			get { return priceClose; }
			set { priceClose = value; }
		}

		private double volume;

		public double Volume
		{
			get { return volume; }
			set { volume = value; }
		}

	}
}
