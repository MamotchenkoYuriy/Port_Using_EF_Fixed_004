using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Finished
    /// </summary>
    public class Ship : BaseEntity
    {
        public string Number { get; set; }
        public int Capacity { get; set; }
        public DateTime CreateDate { get; set; }
        public int MaxDistance { get; set; }
        public int TeamCount { get; set; }
        public int PortId { get; set; }
        public Port Port { get; set; }
        public int CaptainId { get; set; }
        public virtual Captain Captain { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }

        public Ship()
        {
            Trips = new List<Trip>();
        }

        public Ship(string number, int capacity, DateTime createDate, int maxDistance, int teamCount,
            int portId, int captainId)
        {
            this.Number = number;
            this.Capacity = capacity;
            this.CreateDate = createDate;
            this.MaxDistance = maxDistance;
            this.TeamCount = teamCount;
            this.PortId = portId;
            this.CaptainId = captainId;
            Trips = new List<Trip>();
        }

        public override string ToString()
        {
            return String.Format("", Environment.NewLine, Id, Number, Capacity, CreateDate, MaxDistance, TeamCount,
                PortId, CaptainId);
        }
    }
}

