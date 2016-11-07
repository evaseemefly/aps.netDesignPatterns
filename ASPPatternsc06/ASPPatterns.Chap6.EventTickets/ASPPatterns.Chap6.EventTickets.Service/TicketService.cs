using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using ASPPatterns.Chap6.EventTickets.Contracts;
using ASPPatterns.Chap6.EventTickets;
using ASPPatterns.Chap6.EventTickets.DataContract;
using ASPPatterns.Chap6.EventTickets.Model;
using ASPPatterns.Chap6.EventTickets.Repository; 

namespace ASPPatterns.Chap6.EventTickets.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = 
         AspNetCompatibilityRequirementsMode.Allowed)]
    public class TicketService : ITicketService 
    {
        /// <summary>
        /// 事件仓储接口
        /// </summary>
        private IEventRepository _eventRepository;

        /// <summary>
        /// 
        /// </summary>
        private static MessageResponseHistory<PurchaseTicketResponse> _reservationResponse = new MessageResponseHistory<PurchaseTicketResponse>();
        
        public TicketService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public TicketService() : this (new EventRepository()) // Poor mans DI
        { }

        /// <summary>
        /// 订票
        /// </summary>
        /// <param name="reserveTicketRequest">订票请求</param>
        /// <returns></returns>
        public ReserveTicketResponse ReserveTicket(ReserveTicketRequest reserveTicketRequest)
        {           
            ReserveTicketResponse response = new ReserveTicketResponse();

            try
            {
                Event my_Event = _eventRepository.FindBy(new Guid(reserveTicketRequest.EventId));
                TicketReservation reservation;
                //判断是否有传入的请求中所要求的预定票数
                if (my_Event.CanReserveTicket(reserveTicketRequest.TicketQuantity)   )
                {
                    //预定指定数量的门票
                    reservation = my_Event.ReserveTicket(reserveTicketRequest.TicketQuantity);
                    _eventRepository.Save(my_Event);
                    //获取预定门票响应
                    response = reservation.ConvertToReserveTicketResponse();
                    response.Success = true;
                }
                else                
                {
                    response.Success = false;
                    response.Message = String.Format("There are {0} ticket(s) available.", my_Event.AvailableAllocation());             
                }
               
            }
            catch (Exception ex)
            {
                // Shield Exceptions
                response.Message = ErrorLog.GenerateErrorRefMessageAndLog(ex);
                response.Success = false;
            }            
            return response;
        }

        /// <summary>
        /// 购票
        /// </summary>
        /// <param name="PurchaseTicketRequest">购票请求</param>
        /// <returns></returns>
        public PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest PurchaseTicketRequest)
        {
            PurchaseTicketResponse response = new PurchaseTicketResponse();

            try
            {
                // Check for a duplicate transaction using the Idempotent Pattern,
                // the Domain Logic could cope but we can't be sure.
                //判断该请求在字典仓储中是否唯一
                if (_reservationResponse.IsAUniqueRequest(PurchaseTicketRequest.CorrelationId))
                {                
                    TicketPurchase ticket;
                    //找到指定的事件
                    Event my_event = _eventRepository.FindBy(new Guid(PurchaseTicketRequest.EventId));

                    //判断该票是否已经预定
                    if (my_event.CanPurchaseTicketWith(new Guid(PurchaseTicketRequest.ReservationId)))
                    {
                        //根据购票id购票
                        ticket = my_event.PurchaseTicketWith(new Guid(PurchaseTicketRequest.ReservationId));
                        //保存事件
                        _eventRepository.Save(my_event);

                        response = ticket.ConvertToPurchaseTicketResponse();
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = my_event.DetermineWhyATicketCannotbePurchasedWith(new Guid(PurchaseTicketRequest.ReservationId));
                        response.Success = false;
                    }
                   
                    _reservationResponse.LogResponse(PurchaseTicketRequest.CorrelationId, response);
                }            
                else
                {
                    // Retrieve last response
                    response = _reservationResponse.RetrievePreviousResponseFor(PurchaseTicketRequest.CorrelationId);
                }
            }
            catch (Exception ex)
            {
                // Shield Exceptions
                response.Message = ErrorLog.GenerateErrorRefMessageAndLog(ex);
                response.Success = false;
            }   

            return response;             
        }        
    }
}
