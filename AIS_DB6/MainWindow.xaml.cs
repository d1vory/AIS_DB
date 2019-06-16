using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using AIS_DB6.Models;
using AIS_DB6.ViewModels;
using AIS_DB6.ViewModels.GoodsGroups;
using AIS_DB6.ViewModels.Producers;
using AIS_DB6.ViewModels.Suppliers;
using AIS_DB6.Views;
using AIS_DB6.Views.Clients;
using AIS_DB6.Views.Contracts;
using AIS_DB6.Views.Contract__Clauses;
using AIS_DB6.Views.GoodsGroups;
using AIS_DB6.Views.Invoices;
using AIS_DB6.Views.Invoice__lines_Goods;
using AIS_DB6.Views.Invoice__lines_Work;
using AIS_DB6.Views.Producers;
using AIS_DB6.Views.Workers;

namespace AIS_DB6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();



            //Frame f = new Frame();
            //f.Content = new DirectorMainPage();

            //ContractTable ct = new ContractTable();
            //this.Content = ct;

            //ContractClausesTable cct = new ContractClausesTable();
            //this.Content = cct;

            //InvoiceTable it = new InvoiceTable();
            //this.Content = it;

            //InvoiceLinesGoodsTable ilgt = new InvoiceLinesGoodsTable();
            //this.Content = ilgt;

            InvoiceLinesWorkTable ilw = new InvoiceLinesWorkTable();
            this.Content = ilw;

            //WorkerTable wt = new WorkerTable();
            //this.Content = wt;

            //ClientsTable ct = new ClientsTable();
            //this.Content = ct;

            //DirectorMainPage dirPage = new DirectorMainPage();
            //this.Content = dirPage;

            //AdminMainPage ap = new AdminMainPage();
            //this.Content = ap;

            //GoodsTable gt = new GoodsTable();
            //this.Content = gt;

            //ProducerTable pt = new ProducerTable();
            //this.Content = pt;

            //GoodsGroupTable ggt = new GoodsGroupTable();
            //this.Content = ggt;

            //GoodsAdding ga = new GoodsAdding();
            //this.Content = ga;

            //LoginWindow lw = new LoginWindow();
            //lw.Show();
        }

        private void GoodsButton_OnClick(object sender, RoutedEventArgs e)
        {
            DataContext = new GoodsViewModel();
        }

        private void GoodsGroupButton_OnClick(object sender, RoutedEventArgs e)
        {
            DataContext = new GoodsGroupViewModel();
        }

        private void Producers_OnClick(object sender, RoutedEventArgs e)
        {
            DataContext = new ProducerViewModel();
        }

        private void Suppliers_OnClick(object sender, RoutedEventArgs e)
        {
            DataContext = new SupplierViewModel();
        }
    }
}
