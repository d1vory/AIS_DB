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
    class ContractAddingViewModel:CrudVMBase
    {
        private RelayCommand _saveCommand;



        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return SelectedSignDate != null && SelectedTerminationDate != null;
        }

        private async void SaveImplementation(object obj)
        {

            if (SelectedSignDate > SelectedTerminationDate)
            {
                MessageBox.Show("Дата закінчення мусить бути більшою за дату підписання");
                return;
            }
            Contract ct = new Contract();
            ct.ContractId = 0;
            ct.TerminationDate = SelectedTerminationDate;
            ct.SignDate = SelectedSignDate;
            ct.SupplierId = SelectedSupplierId;


            db.Contracts.Add(ct);
            await db.SaveChangesAsync();

            Thiswindow.Close();
        }


        private Window _thiswindow;

        public Window Thiswindow
        {
            get => _thiswindow;
            set => _thiswindow = value;
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

        private List<int> _supplierIds;

        public List<int> SupplierIds
        {
            get => _supplierIds;
            set => _supplierIds = value;
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
       
       

        protected async override void GetData()
        {
            await Task.Run(() =>
            {
               

                OnPropertyChanged();
                foreach (Supplier s in db.Suppliers)
                {
                    SupplierIds.Add(s.SupplierId);
                }

                OnPropertyChanged();

            });



        }

        public ContractAddingViewModel(Window w) : base()
        {
            
            SupplierIds = new List<int>();
            Thiswindow = w;
        }

    }
}
