using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TNS.Domain;
using TNS.Logic;
using TNS.Database;

namespace TNS.Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            ControllerService controllerService = new ControllerService();

            using (var dbContext = new TelecommunicationNetworkSimulatorContext())
            {
                List<Thread> threads = new List<Thread>();
                foreach (var user in dbContext.Users)
                {
                    threads.Add(
                        new Thread(
                            new ThreadStart(
                                () => user.StartChanceCalculation(controllerService)
                                )
                            )
                        );
                }

                foreach (var thr in threads)
                {
                    thr.Start();
                }
            }

        }
    }
}
