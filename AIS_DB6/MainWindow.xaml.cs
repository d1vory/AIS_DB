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
using AIS_DB6.Views;
using AIS_DB6.Views.Producers;

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

           
            
            

            //DirectorMainPage dirPage = new DirectorMainPage();
            //this.Content = dirPage;

            //AdminMainPage ap = new AdminMainPage();
            //this.Content = ap;

            //GoodsTable gt = new GoodsTable();
            //this.Content = gt;

            ProducerTable pt = new ProducerTable();
            this.Content = pt;

            //GoodsAdding ga = new GoodsAdding();
            //this.Content = ga;

            //LoginWindow lw = new LoginWindow();
            //lw.Show();
        }
    }
}
