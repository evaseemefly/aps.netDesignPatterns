using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap6.EventTickets.Model
{
    /// <summary>
    /// 票务购买
    /// </summary>
    public class TicketPurchase
    {
        public Guid Id { get; set; }
        public Event Event { get; set; }


        /// <summary>
        /// 购票数量
        /// </summary>
        public int TicketQuantity { get; set; }
    }
}
