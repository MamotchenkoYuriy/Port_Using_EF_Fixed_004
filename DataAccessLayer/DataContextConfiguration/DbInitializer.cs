using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Core;

namespace DataAccessLayer.DataContextConfiguration
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            #region Cities insert operations
            var listCities = new List<City>();
            for (var i = 0; i < 10; i++)
            {
                listCities.Add(new City() { Name = "City_" + i});
            }

            context.Cities.AddRange(listCities);
            context.SaveChanges();
            #endregion

            #region Ports insert operations
            var listPorts = new List<Port>();
            var firstCity = context.Cities.FirstOrDefault();
            for (var i = 0; i < 10; i++)
            {
                listPorts.Add(new Port() { Name = "Port_" + i, City = firstCity});
            }
            context.Ports.AddRange(listPorts);
            context.SaveChanges();
            #endregion

            #region Captains insert operations
            var listCaptains = new List<Captain>();
            for (var i = 0; i < 10; i++)
            {
                listCaptains.Add(new Captain() { FirstName= "FirstName_" + i, LastName = "LastName_" + i });
            }
            context.Captains.AddRange(listCaptains);
            context.SaveChanges();
            #endregion

            #region CargoTypes insert operations
            var listCargoTypes = new List<CargoType>();
            for (var i = 0; i < 10; i++)
            {
                listCargoTypes.Add(new CargoType() { TypeName= "CargoType_" + i});
            }
            context.CargoTypes.AddRange(listCargoTypes);
            context.SaveChanges();
            #endregion

            #region Ships insert operations
            var listShips = new List<Ship>();
            var firstCaptain = context.Captains.FirstOrDefault();
            var firstPort = context.Ports.FirstOrDefault();
            for (var i = 0; i < 10; i++)
            {
                listShips.Add(new Ship() { Captain = firstCaptain, Port = firstPort, Number = "100500", Capacity = 100500, CreateDate = new DateTime(10, 10, 2010), MaxDistance = 100500, TeamCount = 100500});
            }
            context.Ships.AddRange(listShips);
            context.SaveChanges();
            #endregion

            #region Trips insert operations
            var listTrips = new List<Trip>();
            firstCaptain = context.Captains.FirstOrDefault();
            firstPort = context.Ports.FirstOrDefault();
            var firstShip = context.Ships.FirstOrDefault();
            for (var i = 0; i < 10; i++)
            {
                listTrips.Add(new Trip() { Captain = firstCaptain, PortFrom = firstPort, PortTo = firstPort, Ship = firstShip, StartDate = new DateTime(), EndDate = new DateTime()});
            }
            context.Trips.AddRange(listTrips);
            context.SaveChanges();
            #endregion

            #region Cargoes insert operations
            var listCargo = new List<Cargo>();
            var firstTrip = context.Trips.FirstOrDefault();
            var firstCargoType = context.CargoTypes.FirstOrDefault();

            for (var i = 0; i < 10; i++)
            {
                listCargo.Add(new Cargo() { Trip = firstTrip, CargoType = firstCargoType, Number = 100500, InsurancePrice = 100500, Price = 100500, Weight = 100500});
            }
            context.Carges.AddRange(listCargo);
            context.SaveChanges();
            #endregion

        }
    }
}
