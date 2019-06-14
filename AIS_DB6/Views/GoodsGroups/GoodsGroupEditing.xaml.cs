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
using AIS_DB6.ViewModels.GoodsGroups;

namespace AIS_DB6.Views.GoodsGroups
{
    /// <summary>
    /// Логика взаимодействия для GoodsGroupEditing.xaml
    /// </summary>
    public partial class GoodsGroupEditing : Window
    {
        public GoodsGroupEditing(GoodsGroup gg)
        {
            InitializeComponent();

            DataContext = new GoodsGroupEditingViewModel(this, gg);
        }
    }
}
