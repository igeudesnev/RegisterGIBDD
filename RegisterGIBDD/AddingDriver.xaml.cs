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

namespace RegisterGIBDD
{
    /// <summary>
    /// Interaction logic for AddingDriver.xaml
    /// </summary>
    public partial class AddingDriver : Window
    {
        List<Driver> _drivers = new List<Driver>();

        public AddingDriver()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSurname.Text) != true)
            {
                if (string.IsNullOrWhiteSpace(textBoxName.Text) != true)
                {
                    if (string.IsNullOrWhiteSpace(textBoxDrivinglicense.Text) != true)
                    {
                        Driver driver = new Driver(textBoxSurname.Text, textBoxName.Text, textBoxDrivinglicense.Text);
                        _drivers.Add(driver);
                        using(FileStream fs = new FileStream("drivers.txt", FileMode.OpenOrCreate))
                        {
                            using(StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                            {
                                sw.Write(_drivers[0].Show(textBoxSurname.Text, textBoxName.Text, textBoxDrivinglicense.Text));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Необходимо ввести номер водительского удостоверения");
                        textBoxDrivinglicense.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Необходимо ввести имя водителя");
                    textBoxName.Focus();
                }
            }
            else
            {
                MessageBox.Show("Необходимо ввести фамилию");
                textBoxSurname.Focus();
            }
        }
    }
}
