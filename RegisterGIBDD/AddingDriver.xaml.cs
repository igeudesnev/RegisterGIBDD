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
            if (string.IsNullOrWhiteSpace(textBoxSurname.Text) != true &&
                string.IsNullOrWhiteSpace(textBoxName.Text) != true &&
                string.IsNullOrWhiteSpace(textBoxDrivinglicense.Text) != true)
            {
                uint check = 0;
                    for (int i = 0; i < textBoxSurname.Text.Length; i++)
                    {
                        if (textBoxSurname.Text[i] == '$')
                        {
                            textBoxSurname.Text = null;
                            check += 1;
                            break;
                        }
                    }
                    for (int i = 0; i < textBoxName.Text.Length; i++)
                    {
                        if (textBoxName.Text[i] == '$')
                        {
                            textBoxName.Text = null;
                            check += 1;
                            break;
                        }
                    }
                    for (int i = 0; i < textBoxDrivinglicense.Text.Length; i++)
                    {
                        if (textBoxDrivinglicense.Text[i] == '$')
                        {
                            textBoxDrivinglicense.Text = null;
                            check += 1;
                            break;
                        }
                    }
                if (check == 0)
                {
                    Driver driver = new Driver(textBoxSurname.Text, textBoxName.Text, textBoxDrivinglicense.Text);
                    MainWindow._drivers.Add(driver);
                    using (FileStream fs = new FileStream("drivers.txt", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        jsonFormatter.WriteObject(fs, MainWindow._drivers);
                    }
                    MessageBox.Show("CHPKAWO");
                }
                else
                {
                    MessageBox.Show("Были использованы недопустимые знаки.");
                }
                DialogResult = true;
            }
            else { MessageBox.Show("Поля не должны быть пустыми"); }
        }
    }
}
