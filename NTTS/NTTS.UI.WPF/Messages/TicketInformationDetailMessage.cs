using System;
using System.Collections.Generic;
using System.Text;

namespace NTTS.UI.WPF.Messages
{
    public class TicketInformationDetailMessage
    {
        public int AmountOfSelectedTickets { get; set; }

        public TicketInformationDetailMessage(int amoutOfSelectedTickets)
        {
            AmountOfSelectedTickets = amoutOfSelectedTickets;
        }
    }
}
