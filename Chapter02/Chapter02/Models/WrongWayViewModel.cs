using System;

namespace Chapter02.Models
{
    public class WrongWayViewModel
    {
        DataModel model;

        public WrongWayViewModel()
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
            set { Model.Ticker = value; }
        }

        public DateTime Date
        {
            get { return Model.Date; }
            set { Model.Date = value; }
        }

        public double PriceOpen
        {
            get { return Model.PriceOpen; }
            set { Model.PriceOpen = value; }
        }

        public double PriceHigh
        {
            get { return Model.PriceHigh; }
            set { Model.PriceHigh = value; }
        }

        public double PriceLow
        {
            get { return Model.PriceLow; }
            set { Model.PriceLow = value; }
        }

        public double PriceClose
        {
            get { return Model.PriceClose; }
            set { Model.PriceClose = value; }
        }
    }
}
