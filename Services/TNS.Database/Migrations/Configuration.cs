namespace TNS.Database.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TNS.Domain;
    using TNS.Domain.Utils.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<TNS.Database.TelecommunicationNetworkSimulatorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TNS.Database.TelecommunicationNetworkSimulatorContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            var random = new Random();

            //Subscription Types

            context.SubscriptionTypes.AddOrUpdate(new SubscriptionType() { SecondsTotal = 1200, Name = "Шалений день" });
            context.SubscriptionTypes.AddOrUpdate(new SubscriptionType() { SecondsTotal = 600, Name = "Smart тариф" });
            context.SubscriptionTypes.AddOrUpdate(new SubscriptionType() { SecondsTotal = 999999999, Name = "Unlim+" });

            var subscriptionTypes = context.SubscriptionTypes.ToList();

            //Base Stations


            var baseStations = new List<BaseStation>();
            for (int i = 0; i < 6; i++)
            {
                baseStations.Add(new BaseStation() { BaseStationStatusId = (int)BaseStationStatus.IsStopped, Capacity = 100 });
            }
            context.BaseStations.AddRange(baseStations);


            //Users
            var newUsers = new List<User>();

            for (int i = 0; i < 100; i++)
            {
                int randomSubscriptionTypeIndex = random.Next(subscriptionTypes.Count - 1);
                int randomBaseStationIndex = random.Next(baseStations.Count - 1);
                int randomSecondsLeft = random.Next(subscriptionTypes[randomSubscriptionTypeIndex].SecondsTotal);
                string randomPhoneNumber = "0660000" + random.Next(9999 + 1).ToString("D4");

                var user = new User()
                {
                    FullName = $"User Name {i}",
                    SecondsLeft = randomSecondsLeft,
                    Number = randomPhoneNumber,
                    SubscriptionType = subscriptionTypes[randomSubscriptionTypeIndex],
                    UserStatusId = (int)UserStatus.Free

                };
                user.BaseStation = baseStations[randomBaseStationIndex];

                if ((context.Users.FirstOrDefault(u => u.Number == user.Number) == null)
                    && (newUsers.FirstOrDefault(n => n.Number == user.Number) == null))
                {
                    newUsers.Add(user);
                }

                context.Users.AddRange(newUsers);
            }


            //Constants 
            context.Constants.AddOrUpdate(new Constants() { UserCallChance = 30, UserTravelChance = 10, CallDelay = 60 });

            context.SaveChanges();

        }

    }
}

