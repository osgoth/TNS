using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Domain
{
    public class User
    {
        public int Id { get; set; }
        public int BaseStationId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public int UserStatusId { get; set; }
        public DateTime MinutesLeft { get; set; }
        public string FullName { get; set; }
        public string Number { get; set; }


        public BaseStation BaseStation { get; set; }
        public SubscriptionType SubscriptionType { get; set; }

    }
}
