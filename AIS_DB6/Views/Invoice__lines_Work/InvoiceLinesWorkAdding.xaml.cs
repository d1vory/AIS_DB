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
using AIS_DB6.ViewModels.Invoice__lines_Work;

namespace AIS_DB6.Views.Invoice__lines_Work
{
    /// <summary>
    /// Логика взаимодействия для InvoiceLinesWorkAdding.xaml
    /// </summary>
    public partial class InvoiceLinesWorkAdding : Window
    {
        public InvoiceLinesWorkAdding()
        {
            InitializeComponent();
            DataContext = new InvoiceLinesWorkAddingViewModel(this);
        }

       


        public DateTime? StartDate
        {
            get => myDate.SelectedDate;
            
        }

       


        public string WorkCost
        {
            get => myWorkCost.Text;
            set => myWorkCost.Text = value;
        }


     
        public int WorkerId
        {
            get => (int)WorkerCB.SelectedItem;
            
        }
        

        public string WorkType
        {
            get => myTypeWork.Text;
            set => myTypeWork.Text = value;
        }

        public InvoiceLinesWorkAdding(Models.InvoiceLinesWork ilw)
        {
            InitializeComponent();
            DataContext = new InvoiceLinesWorkEditingViewModel(this,ilw);
        }

        private void SaveBTN_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
