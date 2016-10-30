using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap6.EventTickets.Model
{
    public class TicketPurchaseFactory
    {
        /// <summary>
        /// 创建购票对象
        /// </summary>
        /// <param name="Event"></param>
        /// <param name="tktQty"></param>
        /// <returns></returns>
        public static TicketPurchase CreateTicket(Event Event, int tktQty)
        {
            TicketPurchase ticket = new TicketPurchase();

            ticket.Id = Guid.NewGuid();
            ticket.Event = Event;
            ticket.TicketQuantity = tktQty;

            return ticket;
        }
    }
}