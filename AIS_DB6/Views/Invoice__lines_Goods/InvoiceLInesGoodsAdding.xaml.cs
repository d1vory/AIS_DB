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
using AIS_DB6.ViewModels.invoice__lines_Goods;

namespace AIS_DB6.Views.Invoice__lines_Goods
{
    /// <summary>
    /// Логика взаимодействия для InvoiceLInesGoodsAdding.xaml
    /// </summary>
    public partial class InvoiceLInesGoodsAdding : Window
    {
        public InvoiceLInesGoodsAdding()
        {
            InitializeComponent();
            DataContext = new InvoiceLinesGoodsAddingViewModel(this);
        }

        public InvoiceLInesGoodsAdding(InvoiceLinesGoods ilg)
        {
            InitializeComponent();

            DataContext = new InvoiceLinesGoodsEditingViewModel(this,ilg);
        }
    }
}
