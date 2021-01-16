using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int SecondsLeft { get; set; }
        public string FullName { get; set; }

        [Index(IsUnique = true)]
        [StringLength(200)]
        public string Number { get; set; }


        public BaseStation BaseStation { get; set; }
        public SubscriptionType SubscriptionType { get; set; }

    }
}
