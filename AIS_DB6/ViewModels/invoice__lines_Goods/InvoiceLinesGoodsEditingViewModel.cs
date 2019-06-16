using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.invoice__lines_Goods
{
    class InvoiceLinesGoodsEditingViewModel:CrudVMBase
    {
        private RelayCommand _saveCommand;



        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return GoodsQuantity != 0;
        }

        private void SaveImplementation(object obj)
        {
            



            InvoiceLinesGoods cc = db.InvoiceLinesGoods.SingleOrDefault(c =>
                c.InvoiceId == SelectedInvoiceId && c.GoodsId == SelectedGoodId);

            if (cc != null)
            {
                cc.InvoiceId = SelectedInvoiceId;
                cc.GoodsId = SelectedGoodId;
                cc.Quantity = GoodsQuantity;
                cc.Good = db.Goods.Find(SelectedGoodId);
                cc.Invoice = db.Invoices.Find(SelectedInvoiceId);
                db.SaveChanges();
            }

            Thiswindow.Close();
        }

       


        private Window _thiswindow;

        public Window Thiswindow
        {
            get => _thiswindow;
            set => _thiswindow = value;
        }

       


        private List<int> _goodIds;

        public List<int> GoodIds
        {
            get => _goodIds;
            set => _goodIds = value;
        }



        private List<int> _invoiceIds;

        public List<int> InvoiceIds
        {
            get => _invoiceIds;
            set => _invoiceIds = value;
        }

        private int _selectedGoodId;

        public int SelectedGoodId
        {
            get => _selectedGoodId;
            set
            {
                _selectedGoodId = value;
                OnPropertyChanged();
            }
        }

        private int _selectedInvoiceId;

        public int SelectedInvoiceId
        {
            get => _selectedInvoiceId;
            set
            {
                _selectedInvoiceId = value;
                OnPropertyChanged();
            }
        }

        private int _goodsQuantity;

        public int GoodsQuantity
        {
            get => _goodsQuantity;
            set
            {
                _goodsQuantity = value;
                OnPropertyChanged();
            }
        }



        protected async override void GetData()
        {
            await Task.Run(() =>
            {
                foreach (Good gg in db.Goods)
                {
                    GoodIds.Add(gg.GoodsId);
                }

                OnPropertyChanged();
                foreach (Invoice pp in db.Invoices)
                {
                    InvoiceIds.Add(pp.InvoiceId);
                }



            });

        }

        public  InvoiceLinesGoodsEditingViewModel(Window w,  InvoiceLinesGoods ilg) : base()
        {
            GoodIds = new List<int>();
            InvoiceIds = new List<int>();
            Thiswindow = w;

            GoodsQuantity = ilg.Quantity;
            SelectedInvoiceId = ilg.InvoiceId;
            SelectedGoodId = ilg.GoodsId;


        }

    }
}
