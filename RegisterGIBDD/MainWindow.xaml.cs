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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

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
            ReadToList();
            ListToGrid();
        }

        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Driver>));
        
        static public List<Driver> _drivers = new List<Driver>();

        private void ListToGrid()
        {
            dataGridDrivers.ItemsSource = null;
            dataGridDrivers.ItemsSource = _drivers;
        }

        private void ListToFile()
        {
            using (FileStream fs = new FileStream("drivers.txt", FileMode.Create, FileAccess.Write))
            {
                jsonFormatter.WriteObject(fs, _drivers);
            }
        }

        private void ListToFileAndGrid()
        {
            ListToFile();
            ListToGrid();
        }

        private void ReadToList()
        {
            if (File.Exists("drivers.txt"))
            {
                using (FileStream fs = new FileStream("drivers.txt", FileMode.Open, FileAccess.Read))
                {
                    _drivers = (List<Driver>)jsonFormatter.ReadObject(fs);
                }
            }
        }

        private void buttonAdding_Click(object sender, RoutedEventArgs e)
        {
            AddingDriver addingdriver = new AddingDriver();
            addingdriver.ShowDialog();
            ListToFileAndGrid();
        }        
        
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDrivers.SelectedIndex != -1)
            {
                _drivers.RemoveAt(dataGridDrivers.SelectedIndex);
            }
            ListToFileAndGrid();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowEditing editingdriver = new WindowEditing();
            int index = dataGridDrivers.SelectedIndex;
            if (index != -1) {
                Driver._auxSurname = _drivers[index].Surname;
                Driver._auxName = _drivers[index].Name;
                Driver._auxDrivingLicenseNumber = _drivers[index].DrivingLicenseNumber;
                Driver._auxCar1 = _drivers[index].Car1;
                Driver._auxCar2 = _drivers[index].Car2;
                Driver._auxCar3 = _drivers[index].Car3;
                _drivers.RemoveAt(index);
                editingdriver.ShowDialog();
            }            
            ListToFileAndGrid();
        }
    }
}
