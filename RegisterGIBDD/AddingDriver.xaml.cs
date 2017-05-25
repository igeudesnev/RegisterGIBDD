using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace RegisterGIBDD
{
    /// <summary>
    /// Interaction logic for AddingDriver.xaml
    /// </summary>
    public partial class AddingDriver : Window
    {
        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Driver>));

        public AddingDriver()
        {
            InitializeComponent();
        }        

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                    if (string.IsNullOrWhiteSpace(textBoxSurname.Text) != true &&
                        string.IsNullOrWhiteSpace(textBoxName.Text) != true &&
                        string.IsNullOrWhiteSpace(textBoxDrivinglicense.Text) != true)
                    {
                        textBoxDrivinglicense.Text.Replace(" ", "");
                        Driver driver = new Driver(textBoxSurname.Text, textBoxName.Text, int.Parse(textBoxDrivinglicense.Text),
                            textBoxCar1.Text, textBoxCar2.Text, textBoxCar3.Text);
                        MainWindow._drivers.Add(driver);
                        MessageBox.Show("Saved");
                        Close();
                    }
                    else { MessageBox.Show("Fields should not be empty"); }                
            }
            catch { MessageBox.Show("Data entered incorrectly"); }
        }
    }
}
