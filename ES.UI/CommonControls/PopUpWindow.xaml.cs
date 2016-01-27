using System.ComponentModel;
using System.Windows;

namespace ES.UI.CommonControls
{
    /// <summary>
    /// Interaction logic for PopUpWindow.xaml
    /// </summary>
    public partial class PopUpWindow : Window, INotifyPropertyChanged
    {
        public PopUpWindow()
        {
            InitializeComponent();
        }


        public PopUpWindow(BaseUserControl control, string title, int width = 300, int height = 300)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
            WinTitle = title;
            control.ActualParent = this;
            PopUpContainer.Content = control;
        }
        string _winTitle = "";
        public string WinTitle
        {
            get
            {
                return _winTitle;
            }
            set
            {
                if(_winTitle != value)
                {
                    _winTitle = value;
                    OnPropertyChanged("WinTitle");
                }
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
