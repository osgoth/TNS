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
        // 1 - free
        // 2 - talking
        // 3 - in queue # not realised yet

        public static void StartChanceCalculation(this User user, List<User> users, ControllerService controllerService)
        {
            int callChance;    // in percents
            int callDelay; // in seconds
            using (var dbContext = new TelecommunicationNetworkSimulatorContext())
            {
                callChance = dbContext.Constants.FirstOrDefault().UserCallChance;
                callDelay = dbContext.Constants.FirstOrDefault().CallDelay;
            }

            var rnd = new Random();

            while (true)
            {
                int chanceGenerated = rnd.Next(100);

                if (chanceGenerated > callChance)
                {
                    Thread.Sleep(callDelay * 1000);
                }
                else
                {
                    User otherUser = users.ToList()[rnd.Next(users.Count())];
                    while (otherUser == user && otherUser.UserStatusId != 1)
                    {
                        otherUser = users.ToList()[rnd.Next(users.Count())];
                    }
                    user.Call(otherUser, controllerService);
                }

            }
        }

        public static void Call(this User user, User otherUser, ControllerService controllerService)
        {
            var rnd = new Random();

            Semaphore smp = new Semaphore(1, 1);

            if (otherUser.UserStatusId != 1)
            {
                return;
            }

            smp.WaitOne();
            Monitor.Enter(otherUser);
            controllerService.baseStationCapacity[user.BaseStationId]++;
            controllerService.baseStationCapacity[otherUser.BaseStationId]++;
            user.UserStatusId = 2;
            otherUser.UserStatusId = 2;
            Monitor.Exit(otherUser);
            smp.Release();

            Console.WriteLine($"++ {user.Number} -> {otherUser.Number}");
            Thread.Sleep(rnd.Next(1000, 30000));
            Console.WriteLine($"-- {user.Number} -> {otherUser.Number}");


            smp.WaitOne();
            Monitor.Enter(otherUser);
            controllerService.baseStationCapacity[user.BaseStationId]--;
            controllerService.baseStationCapacity[otherUser.BaseStationId]--;
            user.UserStatusId = 1;
            otherUser.UserStatusId = 1;
            Monitor.Exit(otherUser);
            smp.Release();


        }
    }
}
