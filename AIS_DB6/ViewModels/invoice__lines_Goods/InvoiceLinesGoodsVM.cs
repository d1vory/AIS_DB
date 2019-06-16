using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels.invoice__lines_Goods
{
    class InvoiceLinesGoodsVM:INotifyPropertyChanged
    {
        private InvoiceLinesGoods _theInvoiceLinesGoods;

        public InvoiceLinesGoods TheInvoiceLinesGoods
        {
            get => _theInvoiceLinesGoods;
            set { _theInvoiceLinesGoods = value; OnPropertyChanged(); }
        }


        public InvoiceLinesGoodsVM()
        {
            TheInvoiceLinesGoods = new InvoiceLinesGoods();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
