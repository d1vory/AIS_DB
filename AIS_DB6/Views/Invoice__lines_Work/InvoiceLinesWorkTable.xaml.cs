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
using AIS_DB6.ViewModels.Invoice__lines_Work;

namespace AIS_DB6.Views.Invoice__lines_Work
{
    /// <summary>
    /// Логика взаимодействия для InvoiceLinesWorkTable.xaml
    /// </summary>
    public partial class InvoiceLinesWorkTable : UserControl
    {
        public InvoiceLinesWorkTable()
        {
            InitializeComponent();
            DataContext = new InvoiceLinesWorkViewModel();
        }
    }
}
