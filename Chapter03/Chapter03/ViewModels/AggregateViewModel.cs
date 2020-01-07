﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter03.ViewModels
{
    [Export(typeof(IScreen)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class AggregateViewModel : Screen
    {
        private NorthwindEntities db = new NorthwindEntities();
        private readonly IEventAggregator _events;
        private BindableCollection<AggregateValue> myAggregates;
        private BindableCollection<Pivotdata> myPivots;

        [ImportingConstructor]
        public AggregateViewModel(IEventAggregator events)
        {
            this._events = events;
            DisplayName = "02. Aggregates";
            myAggregates = new BindableCollection<AggregateValue>();
            myPivots = new BindableCollection<Pivotdata>();
        }

        public BindableCollection<AggregateValue> MyAggregates
        {
            get { return myAggregates; }
            set { myAggregates = value; }
        }

        public BindableCollection<Pivotdata> MyPivots
        {
            get { return myPivots; }
            set { myPivots = value; }
        }

        public void GetAggregate()
        {
            using (var db = new NorthwindEntities())
            {
                var query = (from o in db.Orders
                             join e in db.Employees on o.EmployeeID equals e.EmployeeID
                             group new { e, o } by new { e.EmployeeID, e.LastName } into g
                             select new
                             {
                                 EmployeeID = g.Key.EmployeeID,
                                 LastName = g.Key.LastName,
                                 Min = g.Min(x => x.o.Freight),
                                 Max = g.Max(x => x.o.Freight),
                                 Avg = g.Average(x => x.o.Freight),
                                 Sum = g.Sum(x => x.o.Freight)
                             }).OrderBy(p => p.LastName);

                foreach (var q in query)
                {
                    MyAggregates.Add(new AggregateValue
                    {
                        EmployeeID = q.EmployeeID,
                        LastName = q.LastName,
                        Min = (double)q.Min,
                        Max = (double)q.Max,
                        Sum = (double)q.Sum,
                        Avg = (double)q.Avg
                    });
                }
            }
            _events.PublishOnUIThread(
                new ModelEvents(
                    new List<object>(
                        new object[]
                        {
                            "From Aggregates: Count = " + MyAggregates.Count.ToString()
                        }
                    )
                )
            );
        }

        public void GetPivot()
        {
            using (var db = new NorthwindEntities())
            {
                var query = (from o in db.Orders
                             join e in db.Employees on o.EmployeeID equals e.EmployeeID
                             select new { e.LastName, o.OrderDate })
                             .GroupBy(x => x.LastName)
                             .Select(y => new
                             {
                                 LastName = y.Key,
                                 A1996 = (y.Where(z => z.OrderDate.Value.Year == 1996)).Count(),
                                 A1997 = (y.Where(z => z.OrderDate.Value.Year == 1997)).Count(),
                             })
                             .OrderBy(p => p.LastName);

                foreach (var q in query)
                {
                    MyPivots.Add(new Pivotdata
                    {
                        LastName = q.LastName,
                        A1996 = q.A1996,
                        A1997 = q.A1997
                    });
                }
            }
            _events.PublishOnUIThread(new ModelEvents(new List<object>(new object[]
                { "From Pivots: Count = " + MyPivots.Count.ToString() })));

        }
    }

    public class AggregateValue
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Sum { get; set; }
        public double Avg { get; set; }
    }

    public class Pivotdata
    {
        public string LastName { get; set; }
        public int A1996 { get; set; }
        public int A1997 { get; set; }
    }
}
