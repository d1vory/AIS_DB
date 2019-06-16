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
using AIS_DB6.Views.Invoices;


namespace AIS_DB6.ViewModels.Invoices
{
    class InvoiceViewModel:CrudVMBase
    {

        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
        private RelayCommand _printCommand;


        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddImplementation, (o => true)));

        private void AddImplementation(object obj)
        {
            InvoiceAdding ga = new InvoiceAdding();
            //ga.ShowDialog();
            ga.ShowDialog();
            RefreshData();
        }

        public RelayCommand EditCommand =>
            _editCommand ?? (_editCommand = new RelayCommand(EditImplementation, CanExecuteCommand));

        private void EditImplementation(object obj)
        {

            InvoiceAdding ge = new InvoiceAdding(SelectedInvoice.TheInvoice);
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

        private InvoiceVM _selectedInvoice;

        public InvoiceVM SelectedInvoice
        {
            get => _selectedInvoice;
            set
            {
                _selectedInvoice = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<InvoiceVM> _invoices;

        public ObservableCollection<InvoiceVM> Invoices
        {
            get => _invoices;
            set
            {
                _invoices = value;
                base.OnPropertyChanged();

            }
        }

        protected override void RefreshData()
        {
            Invoices.Clear();

            GetData();


        }

        protected async override void GetData()
        {
            db = new AisContext();



            ObservableCollection<InvoiceVM> invoicesTemp = new ObservableCollection<InvoiceVM>();
            var _invoices = await
                (from g in db.Invoices

                 select g).ToListAsync();


            foreach (Invoice invoice in _invoices)
            {
                invoicesTemp.Add(new InvoiceVM() { TheInvoice = invoice });
            }

            Invoices = invoicesTemp;

        }

        protected override void DeleteCurrent()
        {

            if (SelectedInvoice != null)
            {
                db.Invoices.Remove(SelectedInvoice.TheInvoice);
                db.SaveChanges();
                base.RefreshData();
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedInvoice != null;
        }

        public InvoiceViewModel() : base()
        {


        }

    }
}
