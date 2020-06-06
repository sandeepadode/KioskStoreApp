using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFinalExam
{
    public class WindshieldWipers : Item, IShipItem
    {
        private int length;
        public int Length
        {
            get => length;
            set => length = value;
        }
        private bool ship;
        public bool Ship { get => ship; set => ship = value; }

        public int ShipItem()
        {
            return 10;
        }
        public WindshieldWipers(string name, int length, bool ship) 
        {
            this.ItemNumber = 3;
            this.Weight = 1;
            this.Cost = 15;
            this.Name = name;
            this.Length = length;
            this.Ship = ship;
        }
        public WindshieldWipers()
        {

        }
    }
}
