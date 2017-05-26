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
        int index;        

        public WindowEditing(Driver driver, int index)
        {
            this.index = index;
            InitializeComponent();
            textBoxSurname.Text = driver.Surname;
            textBoxName.Text = driver.Name;
            textBoxDrivinglicense.Text = driver.DrivingLicenseNumber.ToString();
            textBoxCar1.Text = driver.Car1;
            textBoxCar2.Text = driver.Car2;
            textBoxCar3.Text = driver.Car3;
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
                    MainWindow._drivers[index] = driver;
                    MessageBox.Show("Saved");
                    Close();
                }
                else { MessageBox.Show("Fields should not be empty"); }
            }
            catch { MessageBox.Show("Data entered incorrectly"); }
        }
        
    }
}
