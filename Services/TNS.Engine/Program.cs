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

            var dbusers = new TelecommunicationNetworkSimulatorContext().Users.ToList();

            List<Thread> threads = new List<Thread>();
            foreach (var user in dbusers)
            {
                threads.Add(
                    new Thread(
                        new ThreadStart(
                            () => user.StartChanceCalculation(dbusers, controllerService)
                            )
                        )
                    );
            }

            foreach (var thr in threads)
            {
                thr.Start();
            }

            Console.WriteLine("DONE!");
        }
    }
}
