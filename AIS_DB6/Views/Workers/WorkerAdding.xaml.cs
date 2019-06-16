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
using AIS_DB6.ViewModels.Workers;

namespace AIS_DB6.Views.Workers
{
    /// <summary>
    /// Логика взаимодействия для WorkerAdding.xaml
    /// </summary>
    public partial class WorkerAdding : Window
    {
        public WorkerAdding()
        {
            InitializeComponent();
            DataContext = new WorkerAddingViewModel(this);
        }

        public WorkerAdding(Worker w)
        {
            InitializeComponent();
            DataContext = new WorkerEditingViewModel(this,w);
        }
    }
}
