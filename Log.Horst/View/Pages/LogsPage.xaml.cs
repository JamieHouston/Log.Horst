﻿using System;
using Log.Horst.ViewModel.Pages;
using ReactiveUI;
using Telerik.UI.Xaml.Controls.Grid;

namespace Log.Horst.View.Pages
{
    public sealed partial class LogsPage : IViewFor<LogsPageViewModel>
    {
        public LogsPage()
        {
            this.InitializeComponent();

            ViewModel = new LogsPageViewModel();
            DataContext = ViewModel;

            this.WhenActivated(WireUpViewModel);

            LogDataGrid.Columns.Add(new DataGridTimeColumn(){PropertyName = "LogTimeStamp" });
            LogDataGrid.Columns.Add(new DataGridTextColumn() { PropertyName = "LoggingLevel" });
            LogDataGrid.Columns.Add(new DataGridTextColumn(){PropertyName = "LogMessage"});
        }

        private void WireUpViewModel(Action<IDisposable> d)
        {
            d(this.Bind(this.ViewModel, vm => vm.Logs, v => v.LogDataGrid.ItemsSource));
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (LogsPageViewModel)value; }
        }

        public LogsPageViewModel ViewModel { get; set; }
    }
}
