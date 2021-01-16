using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TNS.Domain;
using TNS.Database;

namespace TNS.Logic
{
    public static class UserLogic
    {
        // user statuses:
        // 0 - free
        // 1 - talking
        // 2 - in queue

        public static void StartChanceCalculation(this User user, ControllerService controllerService)
        {
            int chance = 30;    // in percents
            int callDelay = 60; // in seconds

            using (var dbContext = new TelecommunicationNetworkSimulatorContext())
            {
                var rnd = new Random();

                while (true)
                {
                    int chanceGenerated = rnd.Next(100);
                    if (
                        dbContext.BaseStations
                        .Where(bs => bs.Id == user.BaseStationId)
                        .FirstOrDefault()
                        .BaseStationStatusId == 1
                        )
                    {
                        if (chanceGenerated > chance)
                        {
                            Thread.Sleep(callDelay * 1000);
                        }
                        else
                        {
                            User otherUser = dbContext.Users.ToList()[rnd.Next(dbContext.Users.Count())];
                            while (otherUser == user)
                            {
                                otherUser = dbContext.Users.ToList()[rnd.Next(dbContext.Users.Count())];
                            }
                            user.Call(otherUser, controllerService);
                        }
                    }
                }
            }
        }

        public static void Call(this User user, User otherUser, ControllerService controllerService)
        {
            var rnd = new Random();

            lock (otherUser)
            {
                if (otherUser.UserStatusId != 0)
                {
                    return;
                }

                controllerService.baseStationCapacity[user.BaseStationId]++;
                controllerService.baseStationCapacity[otherUser.BaseStationId]++;
                user.UserStatusId = 1;
                otherUser.UserStatusId = 1;

                Console.WriteLine($"++ {user.Number} -> {otherUser.Number}");
                Thread.Sleep(rnd.Next(1000, 3000));
                Console.WriteLine($"-- {user.Number} -> {otherUser.Number}");

                controllerService.baseStationCapacity[user.BaseStationId]--;
                controllerService.baseStationCapacity[otherUser.BaseStationId]--;
                user.UserStatusId = 0;
                otherUser.UserStatusId = 0;
            }

        }
    }
}
