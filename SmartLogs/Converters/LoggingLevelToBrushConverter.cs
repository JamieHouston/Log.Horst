﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using SmartLogs.Model;

namespace SmartLogs.Converters
{
    public class LoggingLevelToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var level = (LoggingLevel) value;

            switch (level)
            {
                case LoggingLevel.Verbose:
                    return new SolidColorBrush(Colors.DarkGray);
                case LoggingLevel.Information:
                    return new SolidColorBrush(Colors.DarkCyan);
                case LoggingLevel.Warning:
                    return new SolidColorBrush(Colors.DarkOrange);

                case LoggingLevel.Error:
                    return new SolidColorBrush(Colors.OrangeRed);

                case LoggingLevel.Critical:
                    return new SolidColorBrush(Colors.Red);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
