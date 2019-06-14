using System;

using System.Windows.Controls;

using AIS_DB6.ViewModels.Producers;

namespace AIS_DB6.Views.Producers
{
    /// <summary>
    /// Логика взаимодействия для ProducerTable.xaml
    /// </summary>
    public partial class ProducerTable : Page
    {
        public ProducerTable()
        {
            InitializeComponent();

            DataContext = new ProducerViewModel();
        }
    }
}
