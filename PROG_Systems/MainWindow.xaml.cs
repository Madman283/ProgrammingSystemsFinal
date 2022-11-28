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

namespace PROG_Systems
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        Enviroment enviroment = new Enviroment();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            enviroment.entities = Utility.LoadEntities("../../data/data.xml");
            TextNotes.Text = enviroment.GetAllEntityINFO();
        }

        private void ChangeTime_Click(object sender, RoutedEventArgs e)
        {
            enviroment.TimePasses();
            TextNotes.Text = enviroment.day.ToString() + "\n";
            TextNotes.Text += enviroment.GetAllEntityINFO();
        }
    }
}
