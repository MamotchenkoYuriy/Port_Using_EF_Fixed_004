using System;

namespace Core
{
    public class Cargo : BaseEntity
    {
        public int Number { get; set; }
        public int CargoTypeId { get; set; }
        public virtual CargoType CargoType { get; set; }
        public int Weight { get; set; }
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
        public double Price { get; set; }
        public double InsurancePrice { get; set; }

        public Cargo() { }

        public Cargo(int number, int cargoTypeId, int weight, int tripId, double price, double insurancePrice)
        {
            this.Number = number;
            this.CargoTypeId = cargoTypeId;
            this.Weight = weight;
            this.TripId = tripId;
            this.Price = price;
            this.InsurancePrice = insurancePrice;
        }
        public override string ToString()
        {
            return String.Format("Id --> {1}{0}Number --> {2}{0}CargoTypeId --> {3}{0}Weight --> {4}{0}TripId --> {5}{0}Price --> {6}{0}InsurancePrice --> {7}{0}",
                Environment.NewLine, Id, Number, CargoTypeId, Weight, Weight /*TripId*/, Price, InsurancePrice);
        }
    }
}