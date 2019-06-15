using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
using AIS_DB6.ViewModels.Contracts;

namespace AIS_DB6.Views.Contracts
{
    /// <summary>
    /// Логика взаимодействия для ContractAdding.xaml
    /// </summary>
    public partial class ContractAdding : Window
    {
        public ContractAdding()
        {
            InitializeComponent();
            DataContext = new ContractAddingViewModel(this);
        }

        public ContractAdding(Models.Contract c)
        {
            InitializeComponent();
            DataContext = new ContractEditingViewModel(this,c);
        }
    }
}
