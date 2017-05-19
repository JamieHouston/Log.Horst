using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartLogs.Model;

namespace SmartLogs.ViewModel
{
    public class CollapsibleLogRowViewModel : LogRowViewModelBase
    {
        private ObservableCollection<LogRowViewModel> _subRows;
        public ObservableCollection<LogRowViewModel> SubRows
        {
            get { return _subRows; }
            set { Set(ref _subRows, value); }
        }

        private bool _isCollapsed;
        public bool IsCollapsed
        {
            get { return _isCollapsed; }
            set { Set(ref _isCollapsed, value); }
        }

        public CollapsibleLogRowViewModel()
        {
            SubRows = new ObservableCollection<LogRowViewModel>();
            IsCollapsed = true;
        }

        private RelayCommand _toggleCollapseCommand;
        public RelayCommand ToggleCollapseCommand
        {
            get
            {
                if (_toggleCollapseCommand == null)
                {
                    _toggleCollapseCommand = new RelayCommand(() =>
                    {
                        IsCollapsed = !IsCollapsed;
                    });
                }
                return _toggleCollapseCommand;
            }
        }


    }
}
