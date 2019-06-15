using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.Contracts
{
    class ContractEditingViewModel:CrudVMBase
    {
        private RelayCommand _saveCommand;



        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return SelectedSignDate != null && SelectedTerminationDate != null;
        }

        private void SaveImplementation(object obj)
        {


            Contract c = db.Contracts.SingleOrDefault(g => g.ContractId == ContractId);
            if (c != null)
            {
                c.TerminationDate = SelectedTerminationDate;
                c.SignDate = SelectedSignDate;
                c.SupplierId = SelectedSupplierId;
               
                db.SaveChanges();

            }



            Thiswindow.Close();
        }

        private int _goodId;

        public int GoodId
        {
            get => _goodId;
            set => _goodId = value;
        }


        private Window _thiswindow;

        public Window Thiswindow
        {
            get => _thiswindow;
            set => _thiswindow = value;
        }

        private int _contractId;

        public int ContractId
        {
            get => _contractId;
            set => _contractId = value;
        }

        private int _selectedSupplierId = 1;

        public int SelectedSupplierId
        {
            get => _selectedSupplierId;
            set
            {
                _selectedSupplierId = value; OnPropertyChanged();

            }
        }

        
        private DateTime _selectedSignDate = DateTime.Today;

        public DateTime SelectedSignDate
        {
            get => _selectedSignDate;
            set
            {
                _selectedSignDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime _selectedTerminationDate = DateTime.Today;

        public DateTime SelectedTerminationDate
        {
            get => _selectedTerminationDate;
            set
            {
                _selectedTerminationDate = value;
                OnPropertyChanged();
            }
        }



        private List<int> _supplierIds;

        public List<int> SupplierIds
        {
            get => _supplierIds;
            set => _supplierIds = value;
        }

        

        protected async override void GetData()
        {
            await Task.Run(() =>
            {
               

                OnPropertyChanged();
                foreach (Supplier pp in db.Suppliers)
                {
                    SupplierIds.Add(pp.SupplierId);
                }

                OnPropertyChanged();

            });

        }

        public ContractEditingViewModel(Window w, Contract c) : base()
        {
           
            SupplierIds = new List<int>();
            Thiswindow = w;

            ContractId = c.ContractId;
            SelectedSignDate = c.SignDate;
            SelectedSupplierId = c.SupplierId;
            SelectedTerminationDate = c.TerminationDate;

           
        }
    }
}
