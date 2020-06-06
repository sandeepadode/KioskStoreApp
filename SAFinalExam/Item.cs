using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAFinalExam
{
    [XmlRoot("Items")]
    [XmlInclude(typeof(Tire))]
    [XmlInclude(typeof(Battery))]
    [XmlInclude(typeof(WindshieldWipers))]
    public class Item : INotifyPropertyChanged
    {
        
        private int itemNumber;
        private int cost;
        private int weight;
        private string name;
        private int runningTotal = 0;

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int RunningTotal
        {
            get => runningTotal;
            set { runningTotal = value; Notify("RunningTotal"); }

        }
        public int ItemNumber
        {
            get => itemNumber;
            set => itemNumber = value;
        }
        public int Weight
        {
            get => weight;
            set => weight = value;
        }
        public int Cost
        {
            get => cost;
            set => cost = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public Item()
        {
          
        }

    }
}
