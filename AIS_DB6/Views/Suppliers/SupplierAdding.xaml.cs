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
using AIS_DB6.ViewModels.Suppliers;

namespace AIS_DB6.Views.Suppliers
{
    /// <summary>
    /// Логика взаимодействия для SupplierAdding.xaml
    /// </summary>
    public partial class SupplierAdding : Window
    {
        public SupplierAdding()
        {
            InitializeComponent();
            DataContext = new SupplierAddingViewModel(this);
        }

        public SupplierAdding(Supplier s)
        {
            InitializeComponent();
            DataContext = new SupplierEditingViewModel(this,s);
        }
    }
}
