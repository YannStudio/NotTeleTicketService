using GalaSoft.MvvmLight;
using NTTS.UI.WPF.Messages;

namespace NTTS.UI.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private string _currentPage;
        #endregion

        #region Properties
        public string CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            CurrentPage = "Start";
            MessengerInstance.Register<FrameNavigationMessage>(this, SetFrameNavigation);

        }
        #endregion

        #region Methods

        private void SetFrameNavigation(FrameNavigationMessage message)
        {
            CurrentPage = message.PageName;
        }

        #endregion

    }
}
