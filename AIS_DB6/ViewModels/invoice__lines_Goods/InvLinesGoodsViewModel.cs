using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;
using AIS_DB6.ViewModels.Contracts;
using AIS_DB6.Views.Contracts;
using AIS_DB6.Views.Invoice__lines_Goods;

namespace AIS_DB6.ViewModels.invoice__lines_Goods
{
    class InvLinesGoodsViewModel:CrudVMBase
    {

        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
        


        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddImplementation, (o => true)));

        private void AddImplementation(object obj)
        {
            InvoiceLInesGoodsAdding ga = new InvoiceLInesGoodsAdding();
            //ga.ShowDialog();
            ga.ShowDialog();
            RefreshData();
        }

        public RelayCommand EditCommand =>
            _editCommand ?? (_editCommand = new RelayCommand(EditImplementation, CanExecuteCommand));

        private void EditImplementation(object obj)
        {

            InvoiceLInesGoodsAdding ge = new InvoiceLInesGoodsAdding(SelectedInvoiceLinesGoods.TheInvoiceLinesGoods);
            ge.ShowDialog();



            RefreshData();
        }

        public RelayCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteImplementation, CanExecuteCommand));

        private void DeleteImplementation(object obj)
        {
            try
            {
                DeleteCurrent();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            base.RefreshData();
        }

        private InvoiceLinesGoodsVM _selectedInvoiceLinesGoods;

        public InvoiceLinesGoodsVM SelectedInvoiceLinesGoods
        {
            get => _selectedInvoiceLinesGoods;
            set
            {
                _selectedInvoiceLinesGoods = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<InvoiceLinesGoodsVM> _invoiceLinesGoodses;

        public ObservableCollection<InvoiceLinesGoodsVM> InvoiceLinesGoodses
        {
            get => _invoiceLinesGoodses;
            set
            {
                _invoiceLinesGoodses = value;
                base.OnPropertyChanged();

            }
        }

        protected override void RefreshData()
        {
            InvoiceLinesGoodses.Clear();

            GetData();


        }

        protected async override void GetData()
        {
            db = new AisContext();



            ObservableCollection<InvoiceLinesGoodsVM> invoiceLinesGoodssTemp = new ObservableCollection<InvoiceLinesGoodsVM>();
            var _invoiceLinesGoodss = await
                (from g in db.InvoiceLinesGoods

                 select g).ToListAsync();


            foreach (InvoiceLinesGoods invoiceLinesGoods in _invoiceLinesGoodss)
            {
                invoiceLinesGoodssTemp.Add(new InvoiceLinesGoodsVM() { TheInvoiceLinesGoods = invoiceLinesGoods });
            }

            InvoiceLinesGoodses = invoiceLinesGoodssTemp;

        }

        protected override void DeleteCurrent()
        {

            if (SelectedInvoiceLinesGoods != null)
            {
                db.InvoiceLinesGoods.Remove(SelectedInvoiceLinesGoods.TheInvoiceLinesGoods);
                db.SaveChanges();
                base.RefreshData();
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedInvoiceLinesGoods != null;
        }

        public InvLinesGoodsViewModel() : base()
        {


        }



    }
}
