using System;
using System.Collections.Generic;

namespace Core
{
    public class CargoType : BaseEntity
    {
        public string TypeName { get; set; }
        public virtual ICollection<Cargo> Cargoes { get; set; }
        public CargoType() { Cargoes = new List<Cargo>();}

        public CargoType(string typeName)
        {
            this.TypeName = typeName;
            Cargoes = new List<Cargo>();
        }
        public override string ToString()
        {
            return String.Format("Id --> {1}{0} TypeName --> {2}{0}", Environment.NewLine, Id, TypeName);
        }
    }
}