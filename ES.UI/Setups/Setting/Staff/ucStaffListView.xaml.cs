using ES.BusinessLayer;
using ES.Configurations;
using ES.Entities;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucStaffListView.xaml
    /// </summary>
    public partial class ucStaffListView : BaseUserControl
    {
private IEnumerable<UsersDetail> _staffList;
        public ucStaffListView()
        {
            InitializeComponent();
        }
        public IEnumerable<UsersDetail> StaffList
        {
            get
            {
                return _staffList;
            }
            set
            {
                if(_staffList != value)
                {
                    _staffList = value;
                    NotifyPropertyChanged("StaffList");
                }
            }
        }

        private void RefreshList()
        {
            StaffList = UserDetailRepo.GetAll();
        }

        private UsersDetail GetSelectedStaff()
        {
            return (UsersDetail)gvStaffListView.SelectedItem;
        }
        private void OpenStaffDetailWindow(string mode, string title)
        {
            var win = GetSelectedStaff();
            if (win == null && mode != FormModes.New)
            {
                Message(MessageTypes.Error, "Please Select to "+mode+ " Staff Detail");
                return;
            }

            if (mode == FormModes.New) win = new UsersDetail();

            var view = new ucStaffDetailView(mode, win.UserID);
            view.ParentContainer = this;
            OpenPopUp(view, title, 650,550);
        }
        private void DeleteStaffRecord()
        {
            var win = GetSelectedStaff();
            if (win == null || win.UserID > 0)
            {
                Message(MessageTypes.Error, "Please Select to delete Staff Detail");
                return;
            }
            if(!DeleteMessage())
            {
                return;
            }

            EducationRepo.Remove(win.UserID);
            ExperienceRepo.Remove(win.UserID);
            UserRepo.Remove(win.UserID);
            UserDetailRepo.Remove(win.UserID);
        }


        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            RefreshList();
        }

        private void btnAddStaff_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenStaffDetailWindow(FormModes.New, "Add New Staff");
        }

        private void btnDeleteStaff_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteStaffRecord();
        }

        private void CloseButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Utilities.ClearUserControl();
        }

        private void btnCMDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteStaffRecord();
        }

        private void btnCMView_Click(object sender, RoutedEventArgs e)
        {
            OpenStaffDetailWindow(FormModes.View, "Staff Detail");
        }

        private void btnCMEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenStaffDetailWindow(FormModes.View, "Staff Detail");
        }
        private void btnRefreshStaff_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RefreshList();
        }


    }
}
