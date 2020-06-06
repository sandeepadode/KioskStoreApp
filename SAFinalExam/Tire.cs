using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFinalExam
{
    public class Tire:Item
    {
        private int diameter;
        public int Diameter
        {
            get => diameter;
            set => diameter = value;
        }
        private string modelName;
        public string ModelName
        {
            get => modelName;
            set => modelName = value;
        }
        public Tire(string name, int diameter, string modelName)
        {
            this.ItemNumber = 2;
            this.Weight = 30;
            this.Cost = 200;
            this.Name = name;
            this.Diameter = diameter;
            this.ModelName = modelName;
        }
        public Tire()
        {

        }

    }
}
