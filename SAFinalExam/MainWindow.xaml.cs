using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace SAFinalExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {               
        [XmlArray("Item")]
        [XmlArrayItem("Item", typeof(Tire))]
        [XmlArrayItem("Item", typeof(Battery))]
        [XmlArrayItem("Item", typeof(WindshieldWipers))]
        List<Item> itemsList = new List<Item>();
        Item itemObject = new Item();
        Battery battery;
        WindshieldWipers windShieldWipers;
        Tire tire;

      
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                this.DataContext = itemObject;
            }
            catch (Exception)
            {

                MessageBox.Show("Error occurred while setting the property handler. Please try again!");
            }
           
        }      

        private void ItemType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ItemType.SelectedIndex)
            {
                case 1:
                    TxtWindShieldLength.Visibility = Visibility.Collapsed;
                    LblWindShieldLength.Visibility = Visibility.Collapsed;
                    TxtBatteryVoltage.Visibility = Visibility.Visible;
                    LblBatteryVoltage.Visibility = Visibility.Visible;
                    LblTireDiameter.Visibility = Visibility.Collapsed;
                    TxtTireDiameter.Visibility = Visibility.Collapsed;
                    LblTireModelName.Visibility = Visibility.Collapsed;
                    TxtTireModelName.Visibility = Visibility.Collapsed;
                    LblShipHome.Visibility = Visibility.Visible;
                    RadioYes.Visibility = Visibility.Visible;
                    RadioNo.Visibility = Visibility.Visible;
                    LblItemName.Visibility = Visibility.Visible;
                    TxtItemName.Visibility = Visibility.Visible;
                    BtnSubmit.Visibility = Visibility.Visible;
                    BtnSubmit.Margin = new Thickness(135, 265, 0, 0);
                    break;
                case 2:
                    TxtWindShieldLength.Visibility = Visibility.Collapsed;
                    LblWindShieldLength.Visibility = Visibility.Collapsed;
                    TxtBatteryVoltage.Visibility = Visibility.Collapsed;
                    LblBatteryVoltage.Visibility = Visibility.Collapsed;
                    LblTireDiameter.Visibility = Visibility.Visible;
                    TxtTireDiameter.Visibility = Visibility.Visible;
                    LblTireModelName.Visibility = Visibility.Visible;
                    TxtTireModelName.Visibility = Visibility.Visible;
                    LblShipHome.Visibility = Visibility.Collapsed;
                    RadioYes.Visibility = Visibility.Collapsed;
                    RadioNo.Visibility = Visibility.Collapsed;
                    LblItemName.Visibility = Visibility.Visible;
                    TxtItemName.Visibility = Visibility.Visible;
                    BtnSubmit.Visibility = Visibility.Visible;
                    BtnSubmit.Margin = new Thickness(135, 265, 0, 0);
                    break;
                case 3:
                    TxtWindShieldLength.Visibility = Visibility.Visible;
                    LblWindShieldLength.Visibility = Visibility.Visible;
                    LblTireDiameter.Visibility = Visibility.Collapsed;
                    TxtTireDiameter.Visibility = Visibility.Collapsed;
                    LblTireModelName.Visibility = Visibility.Collapsed;
                    TxtTireModelName.Visibility = Visibility.Collapsed;
                    TxtBatteryVoltage.Visibility = Visibility.Collapsed;
                    LblBatteryVoltage.Visibility = Visibility.Collapsed;
                    LblShipHome.Visibility = Visibility.Visible;
                    RadioYes.Visibility = Visibility.Visible;
                    RadioNo.Visibility = Visibility.Visible;
                    LblItemName.Visibility = Visibility.Visible;
                    TxtItemName.Visibility = Visibility.Visible;
                    BtnSubmit.Visibility = Visibility.Visible;
                    BtnSubmit.Margin = new Thickness(135, 265, 0, 0);
                    break;
                default:
                    break;
            }
            
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ItemType.SelectionBoxItem.ToString() == "Batteries" && (RadioYes.IsChecked == true || RadioNo.IsChecked == true))
                {
                    if (TxtItemName.Text.Trim() != "" && (TxtBatteryVoltage.Text.Trim() != "" && TxtBatteryVoltage.Text.Trim() != "0"))
                    {
                        if (RadioYes.IsChecked == true)
                        {
                            battery = new Battery(TxtItemName.Text, int.Parse(TxtBatteryVoltage.Text), true);
                            itemsList.Add(battery);
                            itemObject.RunningTotal = itemObject.RunningTotal + battery.Cost + battery.ShipItem();
                        }
                        else
                        {
                            battery = new Battery(TxtItemName.Text, int.Parse(TxtBatteryVoltage.Text), false);
                            itemsList.Add(battery);
                            itemObject.RunningTotal = itemObject.RunningTotal + battery.Cost;
                        }
                        MessageBox.Show($"{battery.GetType().Name} purchased");
                        TxtItemName.Text = "";
                        TxtBatteryVoltage.Text = "";                        
                    }
                    else
                    {
                        MessageBox.Show("Item Name and Battery Voltage are mandatory");
                    }
                }
                else if (ItemType.SelectionBoxItem.ToString() == "Windshield Wipers" && (RadioYes.IsChecked == true || RadioNo.IsChecked == true))
                {
                    if (TxtItemName.Text.Trim() != "" && (TxtWindShieldLength.Text.Trim() != "" && TxtWindShieldLength.Text.Trim() != "0"))
                    {
                        if (RadioYes.IsChecked == true)
                        {
                            windShieldWipers = new WindshieldWipers(TxtItemName.Text, int.Parse(TxtWindShieldLength.Text), true);
                            itemsList.Add(windShieldWipers);
                            itemObject.RunningTotal = itemObject.RunningTotal + windShieldWipers.Cost + windShieldWipers.ShipItem();
                        }
                        else
                        {
                            windShieldWipers = new WindshieldWipers(TxtItemName.Text, int.Parse(TxtWindShieldLength.Text), false);
                            itemsList.Add(windShieldWipers);
                            itemObject.RunningTotal = itemObject.RunningTotal + windShieldWipers.Cost;
                        }
                        MessageBox.Show($"{windShieldWipers.GetType().Name} purchased");
                        TxtItemName.Text = "";
                        TxtWindShieldLength.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Item Name and Windshield wiper length are mandatory");
                    }
                    
                }
                else if (ItemType.SelectionBoxItem.ToString() == "Tires")
                {
                    if (TxtItemName.Text.Trim() != "" && TxtTireModelName.Text.Trim() != "" && (TxtTireDiameter.Text.Trim() != "" && TxtTireDiameter.Text.Trim() != "0"))
                    {
                        tire = new Tire(TxtItemName.Text, int.Parse(TxtTireDiameter.Text), TxtTireModelName.Text);
                        itemsList.Add(tire);
                        itemObject.RunningTotal = itemObject.RunningTotal + tire.Cost;
                        MessageBox.Show($"Tire purchased");
                        TxtItemName.Text = "";
                        TxtTireModelName.Text = "";
                        TxtTireDiameter.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Please input all the required fields with appropriate data");
                    }
                    
                    
                }
                else
                {
                    MessageBox.Show("Please enter all the mandatory fields.");                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Some error occured while submitting buying the item. Please enter all the fields correctly and retry.");        
            }
        }

        private void BtnSaveHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteToFile(itemsList);                
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Some problem saving the purchase history");
            }
                       
        }

        private void BtnLoadHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReadFromFile(@"./Items.xml");                
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Some error occurred while loading your purchase history.\nPossible Reasons\n1. The file would have been deleted\n2. Entire structure of the history file has been changed.");
            }
        }

        private void TxtItemName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"[^A-Za-z\s]+$");
                e.Handled = regex.IsMatch(e.Text);
                if (e.Handled)
                {
                    MessageBox.Show("Only Alphabets allowed!!.Please Enter Item Name");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please try entering alphabets only");
            }
        }

        private void TxtWindShieldLength_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"[^0-9]+$");
                e.Handled = regex.IsMatch(e.Text);
                if (e.Handled)
                {
                    MessageBox.Show("Only Numbers allowed!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please try entering alphabets only");
            }
        }

        private void TxtTireDiameter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"[^0-9]+$");
                e.Handled = regex.IsMatch(e.Text);
                if (e.Handled)
                {
                    MessageBox.Show("Only Numbers allowed!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please try entering alphabets only");
            }
        }

        private void TxtTireModelName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"[^A-Za-z\s]+$");
                e.Handled = regex.IsMatch(e.Text);
                if (e.Handled)
                {
                    MessageBox.Show("Only Alphabets allowed!!.Please Enter a Model Name");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please try entering alphabets only");
            }
        }

        private void TxtBatteryVoltage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"[^0-9]+$");
                e.Handled = regex.IsMatch(e.Text);
                if (e.Handled)
                {
                    MessageBox.Show("Only Numbers allowed!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please try entering alphabets only");
            }
        }      

        private void BtnMostBoughtItem_Click(object sender, RoutedEventArgs e)
        {   
            var batteryCount = 0;
            var batteryKey = "";
            var tireCount = 0;
            var tireKey = "";
            var windshieldWiperCount = 0;
            var windshieldWiperKey = "";

            try
            {
                
                var query = (from items in itemsList
                            group items by items.GetType().Name into newGroup
                            orderby newGroup.Key
                            select new { newGroup.Key, count = newGroup.Count()});
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {                                    
                        if (item.Key == "Battery")
                        {
                            batteryCount = item.count;
                            batteryKey = item.Key;
                        }
                        else if (item.Key == "Tire")
                        {
                            tireCount = item.count;
                            tireKey = item.Key;
                        }
                        else if (item.Key == "WindshieldWipers")
                        {
                            windshieldWiperCount = item.count;
                            windshieldWiperKey = item.Key;
                        }
                    }
                    if (batteryCount > tireCount && batteryCount > windshieldWiperCount)
                    {
                        MessageBox.Show($"Most Bought Items:\n\n{batteryKey}: {batteryCount}");
                    }
                    else if (tireCount > batteryCount && tireCount > windshieldWiperCount)
                    {
                        MessageBox.Show($"Most Bought Items:\n\n{tireKey}: {tireCount}");
                    }
                    else if (windshieldWiperCount > batteryCount && windshieldWiperCount > tireCount)
                    {
                        MessageBox.Show($"Most Bought Items:\n\n{windshieldWiperKey}: {windshieldWiperCount}");
                    }
                    else if (batteryCount == tireCount && tireCount == windshieldWiperCount)
                    {
                        MessageBox.Show($"Most Bought Items:\n\n{batteryKey}: {batteryCount}\n{tireKey}: {tireCount}\n{windshieldWiperKey}: {windshieldWiperCount}");
                    }
                    else if (batteryCount == tireCount && batteryCount > windshieldWiperCount)
                    {
                        MessageBox.Show($"Most Bought Items:\n\n{batteryKey}: {batteryCount}\n{tireKey}: {tireCount}");
                    }
                    else if (batteryCount == windshieldWiperCount && batteryCount > tireCount)
                    {
                        MessageBox.Show($"Most Bought Items:\n\n{batteryKey}: {batteryCount}\n{windshieldWiperKey}: {windshieldWiperCount}");
                    }
                    else if (tireCount == windshieldWiperCount && tireCount > batteryCount)
                    {
                        MessageBox.Show($"Most Bought Items:\n\n{tireKey}: {tireCount}\n{windshieldWiperKey}: {windshieldWiperCount}");
                    }

                }
                else
                {
                    MessageBox.Show("You did not purchase any item!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some problem while retrieving item data. Please try again.");
            }
        }

        private void WriteToFile(List<Item> items)
        {
            try
            {
                if (items.Count > 0)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));
                    StreamWriter writeToFile = new StreamWriter(@"./Items.xml");
                    serializer.Serialize(writeToFile, items);
                    writeToFile.Close();
                    MessageBox.Show("Purchase history saved successfully!");
                }
                else
                {
                    MessageBox.Show("You cannot save purchase history without purchasing anything.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Some error occured while saving the purchase history. Please re-try!");
            }
           
        }

        private List<Item> ReadFromFile(string filename)
        {
          
                XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Item>));
                StreamReader readFromFile = new StreamReader(filename);
                List<Item> items = (List<Item>)xmlserializer.Deserialize(readFromFile);
            if (itemsList.Count > 0)
            {
                itemsList.Clear();
            }
            
            itemObject.RunningTotal = 0;
                
            try
            {
                if (items.Count() > 0)
                {
                    itemsList = items;
                    foreach (var item in itemsList)
                    {

                        if (item.GetType().Name == "Tire")
                        {
                            tire = (Tire)item;
                            itemObject.RunningTotal += tire.Cost;
                        }
                        else if (item.GetType().Name == "Battery")
                        {
                            battery = (Battery)item;
                            if (battery.Ship == true)
                            {
                                itemObject.RunningTotal += battery.Cost + battery.ShipItem();
                            }
                            else
                            {
                                itemObject.RunningTotal += battery.Cost;
                            }
                        }
                        else if (item.GetType().Name == "WindshieldWipers")
                        {
                            windShieldWipers = (WindshieldWipers)item;
                            if (windShieldWipers.Ship == true)
                            {
                                itemObject.RunningTotal += windShieldWipers.Cost + windShieldWipers.ShipItem();
                            }
                            else
                            {
                                itemObject.RunningTotal += windShieldWipers.Cost;
                            }
                        }

                    }
                    MessageBox.Show("Purchase history loaded successfully");
                }
                else
                {
                    MessageBox.Show("File Empty: There is no purchase history in the file to be loaded.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong while loading the purchase history data. Please try again!");
            }
            readFromFile.Close();
                return items;           
        }
    }
}
