using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap6.EventTickets.DataContract;
using ASPPatterns.Chap6.EventTickets.Model;

namespace ASPPatterns.Chap6.EventTickets.Service
{
    /// <summary>
    /// 购票拓展方法
    /// </summary>
    public static class TicketPurchaseExtensionMethods
    {
        public static PurchaseTicketResponse ConvertToPurchaseTicketResponse(this TicketPurchase ticketPurchase)
        {
            PurchaseTicketResponse response = new PurchaseTicketResponse();

            response.TicketId = ticketPurchase.Id.ToString();
            response.EventName = ticketPurchase.Event.Name;
            response.EventId = ticketPurchase.Event.Id.ToString();
            response.NoOfTickets = ticketPurchase.TicketQuantity;

            return response;
        }
    }
}
