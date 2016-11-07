using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap6.EventTickets.Model
{
    /// <summary>
    /// 订票工厂
    /// </summary>
    public class TicketReservationFactory
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="Event"></param>
        /// <param name="tktQty"></param>
        /// <returns></returns>
        public static TicketReservation CreateReservation(Event Event, int tktQty)
        {
            TicketReservation reservation = new TicketReservation();

            reservation.Id = Guid.NewGuid();
            reservation.Event = Event;
            reservation.ExpiryTime = DateTime.Now.AddMinutes(1);
            reservation.TicketQuantity = tktQty;

            return reservation;
        }
    }
}
