using GalaSoft.MvvmLight;
using NTTS.Models;
using NTTS.Services;
using NTTS.UI.WPF.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace NTTS.UI.WPF.ViewModels
{
    public class SeatingViewModel : ViewModelBase
    {
        #region Fields
        private readonly ISeatingService _seatingService;
        private ObservableCollection<Seat> _seats;
        private Event _selectedEvent;
        private int _amountOfSelectedTickets;
        #endregion

        #region Properties
        public ObservableCollection<Seat> Seats
        {
            get => _seats;
            set
            {
                _seats = value;
            }
        }
        public Event SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                RaisePropertyChanged();
            }
        }
        public int AmountOfSelectedTickets
        {
            get => _amountOfSelectedTickets;
            set
            {
                _amountOfSelectedTickets = value;
                RaisePropertyChanged();

            }
        }

        #endregion

        #region Constructors

        public SeatingViewModel(ISeatingService seatingService)
        {
            _seatingService = seatingService;
            MessengerInstance.Register<EventDetailMessage>(this, onEventDetailMessageReceived);
            MessengerInstance.Register<TicketInformationDetailMessage>(this, onTicketInformationDetailMessageReceived);

        }

        #endregion

        #region Methods
        private void onEventDetailMessageReceived(EventDetailMessage message)
        {
            SelectedEvent = message.EventInfo;
        }

        private void onTicketInformationDetailMessageReceived(TicketInformationDetailMessage message)
        {
            AmountOfSelectedTickets = message.AmountOfSelectedTickets;
            IList<Seat> seats = _seatingService.GetSeats(SelectedEvent, AmountOfSelectedTickets);
            Seats = new ObservableCollection<Seat>(seats);
        }
        #endregion

        #region Commands
        #endregion
    }
}
