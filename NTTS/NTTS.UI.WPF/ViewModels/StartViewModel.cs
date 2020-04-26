using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NTTS.Models;
using NTTS.Services;
using NTTS.UI.WPF.Messages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace NTTS.UI.WPF.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        #region Fields
        private readonly IEventService _eventService;
        private ObservableCollection<Event> _events;
        private Event _selectedEvent;
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

        public Event SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                GetTicketCommand.RaiseCanExecuteChanged();
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
        public void GetTicket() {
            MessengerInstance.Send(new EventDetailMessage(_selectedEvent));
            MessengerInstance.Send(new FrameNavigationMessage("TicketInformation"));
            
        }

        public bool CheckIfEventIsSelected()
        {
            bool itCanExecute = false;
            if(SelectedEvent != null)
            {
                itCanExecute = true;
            }
            return itCanExecute;
        }

        #endregion

        #region Commands
        private RelayCommand _getTicketCommand;
        public RelayCommand GetTicketCommand => _getTicketCommand ??= new RelayCommand(GetTicket, CheckIfEventIsSelected);

        #endregion

    }
}
