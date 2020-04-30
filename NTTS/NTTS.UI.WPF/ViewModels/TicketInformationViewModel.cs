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
            MessengerInstance.Send(new FrameNavigationMessage("Seating"));
            MessengerInstance.Send(new EventDetailMessage(SelectedEvent));
            MessengerInstance.Send(new TicketInformationDetailMessage(AmountSelectedTickets));
        }

        private void increaseTicketAmount()
        {
            AmountSelectedTickets++;
            DecreaseTicketCommand.RaiseCanExecuteChanged();
            IncreaseTicketCommand.RaiseCanExecuteChanged();
        }

        private void decreaseTicketAmount()
        {
            AmountSelectedTickets--;
            DecreaseTicketCommand.RaiseCanExecuteChanged();
            IncreaseTicketCommand.RaiseCanExecuteChanged();
        }

        private void onEventDetailMessageReceived(EventDetailMessage message)
        {
            SelectedEvent = message.EventInfo;
        }

        public bool checkTicketAmountCanDescrease()
        {
            bool result = false;
            if (AmountSelectedTickets != 1)
            {
                result = true;
            }
            return result;
        }

        public bool checkTicketAmountCanIncrease()
        {
            bool result = false;
            if (AmountSelectedTickets != SelectedEvent.AvailableTickets)
            {
                result = true;
            }
            return result;
        }

        #endregion

        #region Commands    
        private RelayCommand _buyTicketCommand;
        private RelayCommand _increaseTicketAmount;
        private RelayCommand _decreaseTicketAmount;
        public RelayCommand BuyTicketCommand => _buyTicketCommand ??= new RelayCommand(buyTicket);
        public RelayCommand IncreaseTicketCommand => _increaseTicketAmount ??= new RelayCommand(increaseTicketAmount, checkTicketAmountCanIncrease);
        public RelayCommand DecreaseTicketCommand => _decreaseTicketAmount ??= new RelayCommand(decreaseTicketAmount, checkTicketAmountCanDescrease);

        #endregion

    }
}
