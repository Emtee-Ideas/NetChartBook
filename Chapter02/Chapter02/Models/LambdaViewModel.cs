using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chapter02.Models
{
    public class LambdaViewModel : INotifyPropertyChanged
    {
		private DataModel model;

		public LambdaViewModel()
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
                OnPropertyChanged(() => Ticker);
            }
        }

        public DateTime Date
        {
            get { return Model.Date; }
            set
            {
                Model.Date = value;
                OnPropertyChanged(() => Date);
            }
        }

        public double PriceOpen
        {
            get { return Model.PriceOpen; }
            set
            {
                Model.PriceOpen = value;
                OnPropertyChanged(() => PriceOpen);
            }
        }

        public double PriceHigh
        {
            get { return Model.PriceHigh; }
            set
            {
                Model.PriceHigh = value;
                OnPropertyChanged(() => PriceHigh);
            }
        }

        public double PriceLow
        {
            get { return Model.PriceLow; }
            set
            {
                Model.PriceLow = value;
                OnPropertyChanged(() => PriceLow);
            }
        }

        public double PriceClose
        {
            get { return Model.PriceClose; }
            set
            {
                Model.PriceClose = value;
                OnPropertyChanged(() => PriceClose);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression.Body.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpr = propertyExpression.Body as MemberExpression;
                string propertyName = memberExpr.Member.Name;
                this.OnPropertyChanged(propertyName);
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
            get { return new CommandModel(UpdateStockExecute, CanUpdateStockExecute); }
        }
    }
}
