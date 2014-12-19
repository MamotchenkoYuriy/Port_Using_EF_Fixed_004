using System;
using System.Collections.Generic;

namespace Core
{
    public class Trip : BaseEntity
    {
        public int ShipId { get; set; }
        public virtual Ship Ship { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int PortFromId { get; set; }
        public Port PortFrom { get; set; }

        public int PortToId { get; set; }
        public Port PortTo { get; set; }

        public int CaptainId { get; set; }
        public virtual Captain Captain { get; set; }

        public virtual ICollection<Cargo> Cargoes { get; set; }

        public Trip() { Cargoes = new List<Cargo>();}
        public Trip(int shipId, DateTime startDate, DateTime endDate, int portFromId, int portToId)
        {
            this.ShipId = shipId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.PortFromId = portFromId;
            this.PortToId = portToId;
            Cargoes = new List<Cargo>();
        }

        public override string ToString()
        {
            return String.Format("Id --> {1}{0}ShipId --> {2}{0}StartDate --> {3}{0}EndDate --> {4}{0}PortFromId --> {5}{0}PortToId --> {6}{0}", Environment.NewLine, Id, ShipId, StartDate, EndDate, PortFromId, PortToId);
        }
    }
}