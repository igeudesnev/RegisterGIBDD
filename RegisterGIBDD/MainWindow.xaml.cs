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

        List<Driver> _drivers = new List<Driver>();

        private void buttonAdding_Click(object sender, RoutedEventArgs e)
        {
            AddingDriver addingdriver = new AddingDriver();
            addingdriver.ShowDialog();            
        }

        private void RefreshListBox()
        {
            listBoxDrivers.ItemsSource = null;
            listBoxDrivers.ItemsSource = _drivers;
        }

    }
}
