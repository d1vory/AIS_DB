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
using AIS_DB6.Views.Contracts;
using AIS_DB6.Views.Tables;

namespace AIS_DB6.ViewModels.Contracts
{
    class ContractViewModel:CrudVMBase
    {

        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
     
       

        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddImplementation, (o => true)));

        private void AddImplementation(object obj)
        {
            ContractAdding ga = new ContractAdding();
            //ga.ShowDialog();
            ga.ShowDialog();
            RefreshData();
        }

        public RelayCommand EditCommand =>
            _editCommand ?? (_editCommand = new RelayCommand(EditImplementation, CanExecuteCommand));

        private void EditImplementation(object obj)
        {

            ContractAdding ge = new ContractAdding(SelectedContract.TheContract);
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

        private ContractVM _selectedContract;

        public ContractVM SelectedContract
        {
            get => _selectedContract;
            set
            {
                _selectedContract = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<ContractVM> _contracts;

        public ObservableCollection<ContractVM> Contracts
        {
            get => _contracts;
            set
            {
                _contracts = value;
                base.OnPropertyChanged();

            }
        }

        protected override void RefreshData()
        {
            Contracts.Clear();

            GetData();


        }

        protected async override void GetData()
        {
            db = new AisContext();



            ObservableCollection<ContractVM> contractsTemp = new ObservableCollection<ContractVM>();
            var _contracts = await
                (from g in db.Contracts

                 select g).ToListAsync();


            foreach (Contract contract in _contracts)
            {
               contractsTemp.Add(new ContractVM() { TheContract = contract,Duration = (contract.TerminationDate - contract.SignDate).Days});
            }

            Contracts = contractsTemp;

        }

        protected override void DeleteCurrent()
        {
            
            if (SelectedContract != null)
            {
                db.Contracts.Remove(SelectedContract.TheContract);
                db.SaveChanges();
                base.RefreshData();
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedContract != null;
        }

        public ContractViewModel() : base()
        {


        }



    }
}
