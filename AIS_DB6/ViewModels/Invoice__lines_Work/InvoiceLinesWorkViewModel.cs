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
using AIS_DB6.Views.Invoice__lines_Work;
using InvoiceLinesWork = AIS_DB6.Models.InvoiceLinesWork;


namespace AIS_DB6.ViewModels.Invoice__lines_Work
{
    class InvoiceLinesWorkViewModel:CrudVMBase
    {
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
        private RelayCommand _printCommand;

        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddImplementation, (o => true)));

        private void AddImplementation(object obj)
        {
            InvoiceLinesWorkAdding pa = new InvoiceLinesWorkAdding();
            //ga.ShowDialog();
            pa.ShowDialog();
            RefreshData();
        }

        public RelayCommand EditCommand =>
            _editCommand ?? (_editCommand = new RelayCommand(EditImplementation, CanExecuteCommand));

        private void EditImplementation(object obj)
        {

            InvoiceLinesWorkAdding pe = new InvoiceLinesWorkAdding(SelectedInvoiceLinesWork.TheInvoiceLinesWork);
            pe.ShowDialog();





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

        private InvoiceLinesWorkVM _selectedInvoiceLinesWork;

        public InvoiceLinesWorkVM SelectedInvoiceLinesWork
        {
            get => _selectedInvoiceLinesWork;
            set
            {
                _selectedInvoiceLinesWork = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<InvoiceLinesWorkVM> _producers;

        public ObservableCollection<InvoiceLinesWorkVM> InvoiceLinesWorks
        {
            get => _producers;
            set
            {
                _producers = value;
                base.OnPropertyChanged();

            }
        }

        protected override void RefreshData()
        {
            InvoiceLinesWorks.Clear();

            GetData();


        }

        protected async override void GetData()
        {
            db = new AisContext();



            ObservableCollection<InvoiceLinesWorkVM> producersTemp = new ObservableCollection<InvoiceLinesWorkVM>();
            var _producers = await
                (from g in db.InvoiceLinesWork

                 select g).ToListAsync();


            foreach (InvoiceLinesWork producer in _producers)
            {
                producersTemp.Add(new InvoiceLinesWorkVM() { TheInvoiceLinesWork = producer });
            }

            InvoiceLinesWorks = producersTemp;

        }

        protected override void DeleteCurrent()
        {
            //TODO do something with number lines
            if (SelectedInvoiceLinesWork != null)
            {
                db.InvoiceLinesWork.Remove(SelectedInvoiceLinesWork.TheInvoiceLinesWork);
                db.SaveChanges();
                base.RefreshData();
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedInvoiceLinesWork != null;
        }

        public InvoiceLinesWorkViewModel() : base()
        {


        }

    }
}
