using Chapter02.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Chapter02.Views
{
    /// <summary>
    /// Interaction logic for WrongWayView.xaml
    /// </summary>
    public partial class WrongWayView : UserControl
    {
        WrongWayViewModel viewModel;

        public WrongWayView()
        {
            InitializeComponent();
            viewModel = (WrongWayViewModel)base.DataContext;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Ticker = "MSFT";
            viewModel.Date = Convert.ToDateTime("7/14/2015");
            viewModel.PriceOpen = 45.45;
            viewModel.PriceHigh = 45.96;
            viewModel.PriceLow = 45.31;
            viewModel.PriceClose = 45.62;
        }
    }
}
