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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace RegisterGIBDD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            RefreshListBox();
        }

      static public  List<Driver> _drivers = new List<Driver>();

        private void buttonAdding_Click(object sender, RoutedEventArgs e)
        {
            AddingDriver addingdriver = new AddingDriver();
            
            if (addingdriver.ShowDialog().Value)
            {
                RefreshListBox();
            }
            
        }

        private void ReadToList()
        {
            string[] mas = File.ReadAllLines("drivers.txt", Encoding.GetEncoding(1251));
            for (int i = 0; i < mas.Length; i++)
            {
                string[] cell = mas[i].Split(new char[] { '$' });
                Driver example = new Driver(cell[0], cell[1], cell[2]);
                _drivers.Add(example);
            }
        }

        private void RefreshListBox()
        {
            listBoxDrivers.ItemsSource = null;
            listBoxDrivers.ItemsSource = _drivers;
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxDrivers.SelectedIndex != -1)
            {
                _drivers.RemoveAt(listBoxDrivers.SelectedIndex);
                RefreshListBox();
            }
        }
    }
}
