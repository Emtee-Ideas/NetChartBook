﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaliburnMicro2.Models;
using System.ComponentModel.Composition;

namespace TestCaliburnMicro2
{
  [Export(typeof(CollectionViewModel))]
  public class CollectionViewModel : PropertyChangedBase
  {
    private readonly IEventAggregator _events;

    [ImportingConstructor]
    public CollectionViewModel(IEventAggregator events)
    {
      _events = events;
      dataCollection = new BindableCollection<DataModel>();
      GetInitialData();
    }

		private BindableCollection<DataModel> dataCollection;

		public BindableCollection<DataModel> DataCollection
		{
			get { return dataCollection; }
			set { dataCollection = value; }
		}


		private void GetInitialData()
    {
			var model = new DataModel
			{
				Ticker = "IBM",
				Date = Convert.ToDateTime("7/14/2015"),
				PriceOpen = 169.43,
				PriceHigh = 169.54,
				PriceLow = 168.24,
				PriceClose = 168.61,
				Volume = 2974900
			};
			dataCollection.Add(model);

			model = new DataModel
			{
				Ticker = "MSFT",
				Date = Convert.ToDateTime("7/14/2015"),
				PriceOpen = 45.45,
				PriceHigh = 45.96,
				PriceLow = 45.31,
				PriceClose = 45.62,
				Volume = 22723700
			};
			dataCollection.Add(model);

			model = new DataModel
			{
				Ticker = "INTC",
				Date = Convert.ToDateTime("7/14/2015"),
				PriceOpen = 29.66,
				PriceHigh = 30.11,
				PriceLow = 29.44,
				PriceClose = 29.65,
				Volume = 39276800
			};
			dataCollection.Add(model);

			model = new DataModel
			{
				Ticker = "IBM",
				Date = Convert.ToDateTime("7/13/2015"),
				PriceOpen = 167.93,
				PriceHigh = 169.89,
				PriceLow = 167.52,
				PriceClose = 169.38,
				Volume = 4225500
			};
			dataCollection.Add(model);

			model = new DataModel
			{
				Ticker = "MSFT",
				Date = Convert.ToDateTime("7/13/2015"),
				PriceOpen = 44.98,
				PriceHigh = 45.62,
				PriceLow = 44.95,
				PriceClose = 45.54,
				Volume = 24994700
			};
			dataCollection.Add(model);

			model = new DataModel
			{
				Ticker = "INTC",
				Date = Convert.ToDateTime("7/13/2015"),
				PriceOpen = 29.27,
				PriceHigh = 29.82,
				PriceLow = 29.19,
				PriceClose = 29.73,
				Volume = 26335600
			};
			dataCollection.Add(model);
		}

		int count = 0;
		public void UpdateStock()
		{
			DataCollection.Add(new DataModel
			{
				Ticker = "AAPL",
				Date = Convert.ToDateTime("7/14/2015"),
				PriceOpen = 126.04,
				PriceHigh = 126.37,
				PriceLow = 125.04,
				PriceClose = 125.61,
				Volume = 31535500
			});
			count++;
			_events.BeginPublishOnUIThread(new ModelEvent(string.Format("AAPL {0} just Added to the stock list.", count)));
		}
  }
}
