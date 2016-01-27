using System;
using System.Windows;

namespace ES.UI.CommonControls
{
    /// <summary>
    /// Interaction logic for MainWindowContainer.xaml
    /// </summary>
    public partial class MainWindowContainer : BaseUserControl
    {
        public MainWindowContainer()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
