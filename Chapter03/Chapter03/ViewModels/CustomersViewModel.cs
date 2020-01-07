using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter03.ViewModels
{
    [Export(typeof(IScreen)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomersViewModel : Screen
    {
        private readonly IEventAggregator _events;
        private BindableCollection<Customer> myCustomers;

        [ImportingConstructor]
        public CustomersViewModel(IEventAggregator events)
        {
            this._events = events;
            DisplayName = "01. Customers";
            myCustomers = new BindableCollection<Customer>();
        }

        public BindableCollection<Customer> MyCustomers
        {
            get { return myCustomers; }
            set { myCustomers = value; }
        }

        public void GetCustomers()
        {
            using (var db = new NorthwindEntities())
            {
                var query = from d in db.Customers select d;
                MyCustomers.Clear();
                MyCustomers.AddRange(query);
            }
            _events.PublishOnUIThread(
                new ModelEvents(
                    new List<object>(
                        new object[] { "From Customers: Count = " + MyCustomers.Count.ToString() }
                    )
                )
            );
        }
    }
}
