using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFinalExam
{
    public class Battery : Item, IShipItem
    {
        private int voltage;
        public int Voltage
        {
            get => voltage;
            set => voltage = value;
        }
        private bool ship;
        public bool Ship { get => ship; set => ship = value; }

        public int ShipItem()
        {
            return 30;
        }
        public Battery(string name, int voltage, bool ship)
        {
            this.ItemNumber = 1;
            this.Weight = 10;
            this.Cost = 100;
            this.Name = name;
            this.Voltage = voltage;
            this.Ship = ship;
        }
        public Battery()
        {

        }
    }
}
