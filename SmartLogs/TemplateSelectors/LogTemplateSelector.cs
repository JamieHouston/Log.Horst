using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SmartLogs.Model;
using SmartLogs.ViewModel;

namespace SmartLogs.TemplateSelectors
{
    public class LogTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NavigationTemplate { get; set; }
        public DataTemplate UserActionTemplate { get; set; }
        public DataTemplate AppEventTemplate { get; set; }
        public DataTemplate NetworkStartTemplate { get; set; }
        public DataTemplate NetworkEndTemplate { get; set; }
        public DataTemplate CollapsibleSectionTemplate { get; set; }
        public DataTemplate MessageTemplate { get; set; }
        public DataTemplate ExceptionTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var logItem = item as LogRowViewModelBase;

            if (logItem == null)
            {
                throw new ArgumentException("item not of expected type which is LogBase");
            }

            var logRow = logItem as LogRowViewModel;

            if (logRow != null)
            {
                if (logRow.Log is UserActionEventLog)
                {
                    return UserActionTemplate;
                }

                if (logRow.Log is NavigationEventLog)
                {
                    return NavigationTemplate;
                }

                if (logRow.Log is AppEventLog)
                {
                    return AppEventTemplate;
                }

                if (logRow.Log is NetworkStartEventLog)
                {
                    return NetworkStartTemplate;
                }

                if (logRow.Log is NetworkStopEventLog)
                {
                    return NetworkEndTemplate;
                }

                if (logRow.Log is MessageLog)
                {
                    return MessageTemplate;
                }

                if (logRow.Log is ExceptionLog)
                {
                    return ExceptionTemplate;
                }
            }

            if (logItem is CollapsibleLogRowViewModel)
            {
                return CollapsibleSectionTemplate;
            }


            return base.SelectTemplateCore(item, container);
        }
    }
}
