using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Log.Horst.View
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
