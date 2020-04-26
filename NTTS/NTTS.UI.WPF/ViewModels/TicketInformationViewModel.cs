using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NTTS.Models;
using NTTS.Services;
using NTTS.UI.WPF.Messages;

namespace NTTS.UI.WPF.ViewModels
{
    public class TicketInformationViewModel : ViewModelBase
    {
        #region Fields
        private readonly IEventService _eventService;
        private Event _selectedEvent;
        private int _amountSelectedTickets;
        #endregion

        #region Properties
        public Event SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                RaisePropertyChanged();
            }
        }

        public int AmountSelectedTickets
        {
            get => _amountSelectedTickets;
            set 
            {
                _amountSelectedTickets = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Constructors
        public TicketInformationViewModel(IEventService eventService)
        {
            _eventService = eventService;
            MessengerInstance.Register<EventDetailMessage>(this, onEventDetailMessageReceived);
            AmountSelectedTickets = 1;
        }
        #endregion

        #region Methods 
        public void buyTicket()
        {              

        }

        private void onEventDetailMessageReceived(EventDetailMessage message)
        {
            SelectedEvent = message.EventInfo;
        }

        #endregion

        #region Commands    
        private RelayCommand _buyTicketCommand;
        public RelayCommand BuyTicketCommand => _buyTicketCommand ??= new RelayCommand(buyTicket);

        #endregion

    }
}
