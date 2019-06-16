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
using AIS_DB6.ViewModels.Clients;

namespace AIS_DB6.Views.Clients
{
    /// <summary>
    /// Логика взаимодействия для ClientsTable.xaml
    /// </summary>
    public partial class ClientsTable : UserControl
    {
        public ClientsTable()
        {
            InitializeComponent();
            DataContext = new ClientViewModel();
        }
    }
}
