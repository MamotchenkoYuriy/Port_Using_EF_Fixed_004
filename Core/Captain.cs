using System;
using System.Collections.Generic;

namespace Core
{
    public class Captain : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Ship> Ships { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }

        public Captain()
        {
            Ships = new List<Ship>(); 
            Trips = new List<Trip>();
        }

        public Captain(string firstName, string lastName)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            Ships = new List<Ship>();
            Trips = new List<Trip>();
        }

        public override string ToString()
        {
            return String.Format("Id --> {1}{0} FirstName --> {2}{0}LastName --> {3}{0}", Environment.NewLine, Id, FirstName, LastName);
        }
    }
}