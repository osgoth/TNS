using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Domain.Utils.Enums
{
    public enum BaseStationStatus
    {
        IsRunning = 1,
        IsStopped = 2
    }

    public enum UserStatus
    {
        Free = 1,
        IsTalking = 2,
        IsInQueue = 3
    }

}
