using GalaSoft.MvvmLight;
using NTTS.Models;
using NTTS.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NTTS.UI.WPF.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        #region Fields
        private readonly IEventService _eventService;
        private ObservableCollection<Event> _events;
        #endregion

        #region Properties
        public ObservableCollection<Event> Events 
        {
            get => _events;
            set
            {
                _events = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public StartViewModel(IEventService eventService)
        {
            _eventService = eventService;
            IList<Event> events = _eventService.GetAllEvents();
            Events = new ObservableCollection<Event>(events);
        }
        #endregion

        #region Methods

        #endregion

        #region Commands

        #endregion

    }
}
