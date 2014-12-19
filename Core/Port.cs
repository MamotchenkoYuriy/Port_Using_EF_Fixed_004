using System;
using System.Collections.Generic;

namespace Core
{
    public class Port : BaseEntity
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public virtual ICollection<Ship> Ships { get; set; }
        public virtual ICollection<Trip> TripsFrom { get; set; }
        public virtual ICollection<Trip> TripsTo { get; set; }

        public Port()
        {
            TripsTo = new List<Trip>(); 
            TripsFrom = new List<Trip>();
            Ships = new List<Ship>();
        }
        public Port(string name, int cityId)
        {
            this.CityId = cityId;
            this.Name = name;
            TripsTo = new List<Trip>();
            TripsFrom = new List<Trip>();
            Ships = new List<Ship>();
        }

        public override string ToString()
        {
            return String.Format("Id --> {1}{0}Name --> {2}{0} CityId --> {3}{0}", Environment.NewLine, Id, Name, CityId);
        }
    }
}