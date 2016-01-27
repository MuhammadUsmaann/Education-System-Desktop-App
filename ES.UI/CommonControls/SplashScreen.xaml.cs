using System;
using System.ComponentModel;
using System.Timers;
using ES.Controls;
using Timer = System.Timers.Timer;

namespace ES.UI.CommonControls
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : INotifyPropertyChanged
    {
        private readonly Timer _timer = new Timer();
        private int _counter;
        private const int Max = 2000;

        private double _progressBarValue;

        public double ProgressBarValue
        {
            get { return _progressBarValue; }
            set
            {
                _progressBarValue = value;
                NotifyPropertyChanged("ProgressBarValue");
            }
        }

        protected void NotifyPropertyChanged(string source)
        {
            PropertyChanged(this,new PropertyChangedEventArgs(source));
        }
        //protected void NotifyPropertyChanged<T, TP>(T source, Expression<Func<T, TP>> pe)
        //{
        //    PropertyChanged.Raise(source, pe);
        //}

        readonly BackgroundWorker _bg = new BackgroundWorker();
        public SplashScreen()
        {
            DataContext = this;
            InitializeComponent();
            _bg.DoWork += BgDoWork;
            _bg.RunWorkerCompleted += BgRunWorkerCompleted;
            _timer.Interval = 10;
            _timer.Elapsed += TimerElapsed;
            _timer.Disposed += TimerDisposed;
            _timer.Enabled = true;
            _timer.Start();
        }

        void TimerDisposed(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => _bg.RunWorkerAsync()));
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            TryCatch.BeginTryCatch(() =>
            {
                _counter = _counter + 20;
                ProgressBarValue = (double)_counter / Max * 100;
                if (_counter != Max) return;
                _timer.Stop();
                _timer.Dispose();
            });
        }

        private void BgRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoginScreen page = new LoginScreen();
            page.Show();
            this.Close();
        }

        void BgDoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void WindowLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            TryCatch.BeginTryCatch(() =>
            {

            });
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}