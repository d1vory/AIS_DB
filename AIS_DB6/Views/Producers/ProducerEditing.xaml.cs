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
using AIS_DB6.ViewModels.Producers;

namespace AIS_DB6.Views.Producers
{
    /// <summary>
    /// Логика взаимодействия для ProducerEditing.xaml
    /// </summary>
    public partial class ProducerEditing : Window
    {
        public ProducerEditing(Producer pr)
        {
            InitializeComponent();

            DataContext = new ProducerEditingViewModel(this, pr);
        }
    }
}
