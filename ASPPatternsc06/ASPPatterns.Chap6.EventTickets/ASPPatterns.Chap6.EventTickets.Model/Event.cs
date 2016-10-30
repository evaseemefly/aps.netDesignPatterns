using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap6.EventTickets.Model
{
    public class Event
    {
        public Event()
        {
            ReservedTickets = new List<TicketReservation>();
            PurchasedTickets = new List<TicketPurchase>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 分配（设置的票务总量）
        /// </summary>
        public int Allocation { get; set; }
        /// <summary>
        /// 预订票集合
        /// </summary>
        public List<TicketReservation> ReservedTickets { get; set; }

        /// <summary>
        /// 购买票集合
        /// </summary>
        public List<TicketPurchase> PurchasedTickets { get; set; }

        /// <summary>
        /// 获取可以用的票务量
        /// </summary>
        /// <returns></returns>
        public int AvailableAllocation()
        {
            //卖掉及预定的数量
            int salesAndReservations = 0;

            //遍历购票集合，修改预定及卖掉的票的数量
            PurchasedTickets.ForEach(t => salesAndReservations += t.TicketQuantity);

            //遍历预定票集合中依然活跃属性，并修改预定及卖掉票的数量
            ReservedTickets.FindAll(r => r.StillActive()).ForEach(r => salesAndReservations += r.TicketQuantity); 
           
            //返回可用票量
            return Allocation - salesAndReservations;
        }
       
        /// <summary>
        /// 可以购买的票（已经存在于预定票务集合中）
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        public bool CanPurchaseTicketWith(Guid reservationId)
        {
            //判断当前传入的id是否是已经预定了，若已经预定了则可以购买
            if (HasReservationWith(reservationId))
                return GetReservationWith(reservationId).StillActive();

            return false;
        }

        /// <summary>
        /// 根据预定票的id购买指定票
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        public TicketPurchase PurchaseTicketWith(Guid reservationId)
        {
            //判断当前id的票是否已经存在于预定票务集合中
            if (!CanPurchaseTicketWith(reservationId))
                //若不存在则抛出一个不能购票的异常
                throw new ApplicationException(DetermineWhyATicketCannotbePurchasedWith(reservationId));

            //若存在则获取该预定的票务对象
            TicketReservation reservation = GetReservationWith(reservationId);

            //创建购票实例
            TicketPurchase ticket = TicketPurchaseFactory.CreateTicket(this, reservation.TicketQuantity);

            //并对预定票对象设置其可赎回属性为true
            reservation.HasBeenRedeemed = true;

            //将购票对象加入购票集合中
            PurchasedTickets.Add(ticket);
           
            return ticket;
        }

        /// <summary>
        /// 根据预定的id取出对应的预订票对象
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        public TicketReservation GetReservationWith(Guid reservationId)
        {
            if (!HasReservationWith(reservationId))
                throw new ApplicationException(String.Format("No reservation ticket with matching id of '{0}'", reservationId.ToString()));

            return ReservedTickets.FirstOrDefault(t => t.Id == reservationId);                       
        }

        /// <summary>
        /// 根据id查询当前的预定票务集合中是否存在指定的预定票
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        private bool HasReservationWith(Guid reservationId)
        {
            return ReservedTickets.Exists(t => t.Id == reservationId);           
        }

        /// <summary>
        /// 获取为什么不能购票的原因
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        public string DetermineWhyATicketCannotbePurchasedWith(Guid reservationId)
        {
            string reservationIssue = "";
            if (HasReservationWith(reservationId))
            {
                TicketReservation reservation = GetReservationWith(reservationId);
                if (reservation.HasExpired())
                    reservationIssue =  String.Format("Ticket reservation '{0}' has expired", reservationId.ToString());
                else if (reservation.HasBeenRedeemed )
                    reservationIssue = String.Format("Ticket reservation '{0}' has already been redeemed", reservationId.ToString());                
            }
            else
                reservationIssue = String.Format("There is no ticket reservation with the Id '{0}'", reservationId.ToString());

            return reservationIssue;
        }

        private void ThrowExceptionWithDetailsOnWhyTicketsCannotBeReserved()
        {            
            throw new ApplicationException("There are no tickets available to reserve.");
        }

        /// <summary>
        /// 是否有足够的门票可供预定
        /// </summary>
        /// <param name="qty"></param>
        /// <returns></returns>
        public bool CanReserveTicket(int qty)
        {
            return AvailableAllocation() >= qty;
        }

        /// <summary>
        /// 预定几张票
        /// </summary>
        /// <param name="tktQty"></param>
        /// <returns></returns>
        public TicketReservation ReserveTicket(int tktQty)
        {
            if (!CanReserveTicket(tktQty))
                ThrowExceptionWithDetailsOnWhyTicketsCannotBeReserved();

            TicketReservation reservation = TicketReservationFactory.CreateReservation(this, tktQty);
           
            ReservedTickets.Add(reservation);  

            return reservation;
        }
    }
}
