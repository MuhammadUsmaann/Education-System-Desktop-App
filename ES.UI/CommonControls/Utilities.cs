using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using ES.UI.CommonControls;
using ES.Entities;
using ES.Configurations;
namespace ES.UI
{
    public class Utilities
    {
        public static Double MainPageHieght = 0;
        public static Double RibbonViewHieght = 0;
        private static UserLoginSession _Loginsession;
        public static UserLoginSession UserSession
        {
            get {
                if (_Loginsession == null)
                {
                    _Loginsession = new UserLoginSession();
                }
                return _Loginsession;
            }
            set {
               
                if( _Loginsession != value)
                {
                    _Loginsession = value;
                }
            }
        }
        public static MainWindow GetMainWindow()
        {
            if (System.Windows.Application.Current.Windows != null && System.Windows.Application.Current.Windows.Count > 0)
            {
                for (int i = 0; i < System.Windows.Application.Current.Windows.Count; i++)
                {
                    if (System.Windows.Application.Current.Windows[i] != null && System.Windows.Application.Current.Windows[i].GetType().Name == "MainWindow")
                    {
                        return (MainWindow)System.Windows.Application.Current.Windows[i];
                    }
                }
            }
            return null;
        }
        public static void ClearUserControl()
        {
            MainWindow main = GetMainWindow();
            if (main != null)
            {
                main.MainContainer.Content = null;
            }
        }

        public static string GetEnumDescriptionFromString<T>(string value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            string des= "";
            foreach (Enum item in Enum.GetValues(typeof(T)))
            {
                if(item.GetCode() == value)
                   des = item.GetDescription();
            }

            return des;
        }
    }
}
