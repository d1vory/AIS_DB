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
using AIS_DB6.Models;
using AIS_DB6.ViewModels.Invoices;

namespace AIS_DB6.Views.Invoices
{
    /// <summary>
    /// Логика взаимодействия для InvoiceAdding.xaml
    /// </summary>
    public partial class InvoiceAdding : Window
    {
        public InvoiceAdding()
        {
            InitializeComponent();
            DataContext = new InvoiceAddingViewModel(this);
        }

        public InvoiceAdding(Invoice inv)
        {
            InitializeComponent();
            DataContext = new InvoiceEdtingViewModel(this,inv);
        }
    }
}
