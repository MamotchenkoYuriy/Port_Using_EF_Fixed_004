using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DataAccessLayer.DataContextConfiguration;
using DataAccessLayer.Manager;
using DataAccessLayer.Repository;
using DataAccessLayer.Validation;

namespace DataAccessLayer.DAO
{
    public class DAOManager
    {
        private readonly DataContext _context;
        private readonly Dictionary<string, object> _dictionaryManamers;
        private static DAOManager instance;
        private readonly Dictionary<string, object> _dictionaryRepositories; 


        private DAOManager()
        {
            _context = new DataContext();
           
            _dictionaryRepositories = new Dictionary<string, object>
            {
                {typeof (City).Name, new Repository.Repository<City>(_context)},
                {typeof (Cargo).Name, new Repository.Repository<Cargo>(_context)},
                {typeof (CargoType).Name, new Repository.Repository<CargoType>(_context)},
                {typeof (Trip).Name, new Repository.Repository<Trip>(_context)},
                {typeof (Captain).Name, new Repository.Repository<Captain>(_context)},
                {typeof (Ship).Name, new Repository.Repository<Ship>(_context)},
                {typeof (Port).Name, new Repository.Repository<Port>(_context)}
            };

            //Засетим все репозитории 

            _dictionaryManamers = new Dictionary<string, object>
            {
                {
                    typeof (Trip).Name,
                    new Manager<Trip>((IRepository<Trip>) _dictionaryRepositories[typeof (Trip).Name],
                        new TripValidator((IRepository<Trip>) _dictionaryRepositories[typeof (Trip).Name]))
                },
                {
                    typeof (City).Name,
                    new Manager<City>((IRepository<City>) _dictionaryRepositories[typeof (City).Name],
                        new CityValidator((IRepository<City>) _dictionaryRepositories[typeof (City).Name]))
                },
                {
                    typeof (Cargo).Name,
                    new Manager<Cargo>((IRepository<Cargo>) _dictionaryRepositories[typeof (Cargo).Name],
                        new CargoValidator((IRepository<Cargo>) _dictionaryRepositories[typeof (Cargo).Name]))
                },
                {
                    typeof (CargoType).Name,
                    new Manager<CargoType>((IRepository<CargoType>) _dictionaryRepositories[typeof (CargoType).Name],
                        new CargoTypeValidator((IRepository<CargoType>) _dictionaryRepositories[typeof (CargoType).Name]))
                },
                {
                    typeof (Ship).Name,
                    new Manager<Ship>((IRepository<Ship>) _dictionaryRepositories[typeof (Ship).Name],
                        new ShipValidator((IRepository<Ship>) _dictionaryRepositories[typeof (Ship).Name]))
                },
                {
                    typeof (Captain).Name,
                    new Manager<Captain>((IRepository<Captain>) _dictionaryRepositories[typeof (Captain).Name],
                        new CaptainValidator((IRepository<Captain>) _dictionaryRepositories[typeof (Captain).Name]))
                },
                {
                    typeof (Port).Name,
                    new Manager<Port>((IRepository<Port>) _dictionaryRepositories[typeof (Port).Name],
                        new PortValidator((IRepository<Port>) _dictionaryRepositories[typeof (Port).Name]))
                }
            };
        }

        public static DAOManager GetInstance()
        {
            if (instance != null)
            {
                return instance;
            }
            instance = new DAOManager();
            return instance;
        }

        public IManager<T> Manager<T>() where T :BaseEntity
        {
            if (_dictionaryManamers.ContainsKey(typeof (T).Name))
            {
                return (IManager<T>)_dictionaryManamers[typeof (T).Name];
            }
            throw new ObjectNotFoundException();
        } 
    }
}
