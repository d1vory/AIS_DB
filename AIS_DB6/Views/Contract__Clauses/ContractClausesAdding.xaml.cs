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
using AIS_DB6.ViewModels.Contract__Clauses;

namespace AIS_DB6.Views.Contract__Clauses
{
    /// <summary>
    /// Логика взаимодействия для ContractClausesAdding.xaml
    /// </summary>
    public partial class ContractClausesAdding : Window
    {
        public ContractClausesAdding()
        {
            InitializeComponent();
            DataContext = new ContractClausesAddingViewModel(this);
        }

        public ContractClausesAdding(ContractClauses cc)
        {
            InitializeComponent();
            DataContext = new ContractClausesEditingViewModel(this,cc);
        }
    }
}
