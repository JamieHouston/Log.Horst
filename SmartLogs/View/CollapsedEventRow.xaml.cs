using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SmartLogs.View
{
    public sealed partial class CollapsedEventRow : UserControl
    {
        public CollapsedEventRow()
        {
            this.InitializeComponent();
        }

        #region public ImageSource IconImageSource

        /// <summary>
        /// Identifies the IconImageSource dependency property.
        /// </summary>
        public static DependencyProperty IconImageSourceProperty =
            DependencyProperty.Register("IconImageSource", typeof (ImageSource), typeof (CollapsedEventRow), null);

        /// <summary>
        /// 
        /// </summary>
        public ImageSource IconImageSource
        {
            get { return (ImageSource) GetValue(IconImageSourceProperty); }

            set { SetValue(IconImageSourceProperty, value); }
        }

        #endregion public ImageSource IconImageSource

        #region public string Message

        /// <summary>
        /// Identifies the Message dependency property.
        /// </summary>
        public static DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(CollapsedEventRow), null);

        /// <summary>
        /// 
        /// </summary>
        public string Message
        {
            get { return (string) GetValue(MessageProperty); }

            set { SetValue(MessageProperty, value); }
        }

        #endregion public string Message

        #region public string Subtitle

        /// <summary>
        /// Identifies the Subtitle dependency property.
        /// </summary>
        public static DependencyProperty SubtitleProperty =
            DependencyProperty.Register("Subtitle", typeof(string), typeof(CollapsedEventRow), null);

        /// <summary>
        /// 
        /// </summary>
        public string Subtitle
        {
            get { return (string) GetValue(SubtitleProperty); }

            set { SetValue(SubtitleProperty, value); }
        }

        #endregion public string Subtitle

        #region public string TooltipMessage

        /// <summary>
        /// Identifies the TooltipMessage dependency property.
        /// </summary>
        public static DependencyProperty TooltipMessageProperty =
            DependencyProperty.Register("TooltipMessage", typeof(string), typeof(CollapsedEventRow), null);

        /// <summary>
        /// 
        /// </summary>
        public string TooltipMessage
        {
            get { return (string) GetValue(TooltipMessageProperty); }

            set { SetValue(TooltipMessageProperty, value); }
        }

        #endregion public string TooltipMessage
    }
}
