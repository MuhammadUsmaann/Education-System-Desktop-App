using ES.BusinessLayer;
using ES.Entities;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace ES.UI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window, INotifyPropertyChanged
    {
        private Boolean isVisible = false;
        private string m_username = null;
        private string m_password = null;
        private string m_oldpassword = null;
        private string m_newpassword = null;
        private string m_confirmpassword = null;

        #region Helper Properties

        public string UserName
        {
            get
            {
                return m_username;
            }
            set
            {
                m_username = value;
                NotifyPropertyChanged("UserName");
            }
        }
        public string Password
        {
            get
            {
                return m_password;
            }
            set
            {
                m_password = value;
                NotifyPropertyChanged("Password");
            }
        }
        public string OldPassword
        {
            get
            {
                return m_oldpassword;
            }
            set
            {
                m_oldpassword = value;
                NotifyPropertyChanged("OldPassword");
            }
        }
        public string NewPassword
        {
            get
            {
                return m_newpassword;
            }
            set
            {
                m_newpassword = value;
                NotifyPropertyChanged("NewPassword");
            }
        }
        public string ConfirmPassword
        {
            get
            {
                return m_confirmpassword;
            }
            set
            {
                m_confirmpassword = value;
                NotifyPropertyChanged("ConfirmPassword");
            }
        }

        #endregion
        public LoginScreen()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        #region Events

        void HideShowWindow()
        {
            if (isVisible)
            {
                OldPassword = null;
                NewPassword = null;
                ConfirmPassword = null;
                isVisible = false;
                LoginWindowScreen.Height = 180;
                OptionsGrid.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                isVisible = true;
                LoginWindowScreen.Height = 370;
                OptionsGrid.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            HideShowWindow();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Password = txtPassword.Password;

            if (string.IsNullOrEmpty(UserName))
            {
                MessageBox.Show("Enter user name");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Enter user password");
                return;
            }

            UsersRepository _userRepo = new UsersRepository();
            Users _user = _userRepo.FindByQuery(" username = '" + UserName + "' AND Password = '" + Password + "'").FirstOrDefault();

            if (_user != null)
            {
                UsersDetail _userDetail = new UsersDetailRepository().FindByUserID(_user.UserID);

                Utilities.UserSession.DisplayName = _userDetail.FullName;
                Utilities.UserSession.UserName = _user.UserName;
                Utilities.UserSession.UserID = _user.UserID;
                Utilities.UserSession.Password = _user.Password;
                Utilities.UserSession.RoleID = _user.RoleID;
                Utilities.UserSession.SchoolName = "So-Business School Management System";

                var session= new SessionRepository().GetAll().Where(p => p.isActive = true).FirstOrDefault();

                Utilities.UserSession.SessionID = session != null ? session.SessionID : 0;
                
                MainWindow page = new MainWindow();
                page.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("User Not Found");
            }

        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(UserName))
            {
                MessageBox.Show("Enter user name");
                return;
            }
            if (!string.IsNullOrEmpty(OldPassword) && !string.IsNullOrEmpty(NewPassword))
            {
                if (!NewPassword.Equals(ConfirmPassword))
                {
                    MessageBox.Show("Password not match");
                    return;
                }

                UsersRepository _userRepo = new UsersRepository();
                Users _user = _userRepo.FindByQuery(" username = '" + UserName + "' AND Password = '" + OldPassword + "'").FirstOrDefault();

                if (_user != null)
                {
                    _user.Password = NewPassword;
                    _userRepo.Update(_user);
                }
                else
                {
                    MessageBox.Show("User Not Found");
                }
            }
            else
            {
                MessageBox.Show("Enter Valid Passwords");
                return;
            }
        }
        private void btnOptionsCancel_Click(object sender, RoutedEventArgs e)
        {
            HideShowWindow();
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
