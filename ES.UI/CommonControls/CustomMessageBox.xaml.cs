using ES.Configurations;
using System.ComponentModel;
using System.Windows;

namespace ES.UI.CommonControls
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window,INotifyPropertyChanged
    {
        private string _windowTitle;
        private string _msgType;
        private string _msg;
        private string _color;
        public event PropertyChangedEventHandler PropertyChanged;
        public CustomMessageBox(string msgType, string msgString)
        {
            InitializeComponent();
            Message = msgString;
            MessageType = msgType;
            initMessageBox();
        }

        private void initMessageBox()
        {
            if (MessageType == MessageTypes.Error)
            {
                Color = ColorList.Red;
                WindowTitle = "Error";
            }
            else if (MessageType == MessageTypes.Information)
            {
                Color = ColorList.Blue;
                WindowTitle = "Information";
            }
            else
            {
                Color = ColorList.Green;
                WindowTitle = "Success";
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    onPropertyChanged("MessageType");
                }
            }
        }
        public string MessageType
        {
            get { return _msgType; }
            set
            {
                if (_msgType != value)
                {
                    _msgType = value;
                    onPropertyChanged("MessageType");
                }
            }
        }
        public string Message
        {
            get { return _msg; }
            set
            {
                if (_msg != value)
                {
                    _msg = value;
                    onPropertyChanged("Message");
                }
            }
        }

        public string WindowTitle
        {
            get
            {
                return _windowTitle;
            }
            set
            {
                if(_windowTitle != value)
                {
                    _windowTitle = value;
                    onPropertyChanged("WindowTitle");
                }
            }
        }


        public void onPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
