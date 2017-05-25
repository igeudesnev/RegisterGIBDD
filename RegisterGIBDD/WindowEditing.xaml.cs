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

namespace RegisterGIBDD
{
    /// <summary>
    /// Interaction logic for WindowEditing.xaml
    /// </summary>
    public partial class WindowEditing : Window
    {
        public WindowEditing()
        {
            InitializeComponent();
            textBoxSurname.Text = Driver._auxSurname;
            textBoxName.Text = Driver._auxName;
            textBoxDrivinglicense.Text = Driver._auxDrivingLicenseNumber.ToString();
            textBoxCar1.Text = Driver._auxCar1;
            textBoxCar2.Text = Driver._auxCar2;
            textBoxCar3.Text = Driver._auxCar3;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
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

        private void Window_Closed(object sender, EventArgs e)
        {
            Driver driver = new Driver(Driver._auxSurname, Driver._auxName, Driver._auxDrivingLicenseNumber,
                       Driver._auxCar1, Driver._auxCar2, Driver._auxCar3);
            MainWindow._drivers.Add(driver);
            MessageBox.Show("Previous version returned");
        }
    }
}
