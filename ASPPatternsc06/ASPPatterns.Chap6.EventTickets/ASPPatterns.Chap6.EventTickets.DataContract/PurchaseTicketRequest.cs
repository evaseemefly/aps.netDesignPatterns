using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ASPPatterns.Chap6.EventTickets.DataContract
{
    [DataContract]
    public class PurchaseTicketRequest
    {
        /// <summary>
        /// 相互关联ID
        /// </summary>
        [DataMember]
        public string CorrelationId { get; set; }

        /// <summary>
        /// 预约id
        /// </summary>
        [DataMember]
        public string ReservationId { get; set; }

        [DataMember]
        public string EventId { get; set; }
    }
}
