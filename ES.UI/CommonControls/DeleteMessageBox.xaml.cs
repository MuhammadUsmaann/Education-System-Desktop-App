using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ES.UI.CommonControls
{
    /// <summary>
    /// Interaction logic for DeleteMessageBox.xaml
    /// </summary>
    public partial class DeleteMessageBox : Window
    {
        public DependencyObject ParentContainer { get; set; }
        public DeleteMessageBox()
        {
            InitializeComponent();
            
        }

        private void CloseWindow(Boolean action)
        {
            BaseUserControl _parent = (BaseUserControl)ParentContainer;
            _parent.CanDelete = action;
            this.Close();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow(false);
        }
        public Boolean CanDelete
        {
            get;
            set;
        }
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow(true);
        }
        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow(false);
        }
    }
}
