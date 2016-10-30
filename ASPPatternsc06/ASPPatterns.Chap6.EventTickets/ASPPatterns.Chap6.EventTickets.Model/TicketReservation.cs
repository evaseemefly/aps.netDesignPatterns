using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap6.EventTickets.Model
{
    /// <summary>
    /// 预定的门票
    /// </summary>
    public class TicketReservation
    {        
        public Guid Id { get; set; }
        public Event Event { get; set; }
        public DateTime ExpiryTime { get; set; }

        /// <summary>
        /// 票数量
        /// </summary>
        public int TicketQuantity { get; set; }

        /// <summary>
        /// 可以被赎回
        /// </summary>
        public bool HasBeenRedeemed { get; set; }

        /// <summary>
        /// 已经过期
        /// </summary>
        /// <returns></returns>
        public bool HasExpired()
        {
            return DateTime.Now > ExpiryTime;
        }

        /// <summary>
        /// 依然活跃
        /// </summary>
        /// <returns></returns>
        public bool StillActive()
        {
            return !HasBeenRedeemed && !HasExpired();
        }
    }
}
