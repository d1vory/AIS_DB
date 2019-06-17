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
using AIS_DB6.Views.Contract__Clauses;
using AIS_DB6.Views.Tables;

namespace AIS_DB6.ViewModels.Contract__Clauses
{
    class ContractClausesViewModel:CrudVMBase
    {
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
        private RelayCommand _printCommand;

        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddImplementation, (o => true)));

        private void AddImplementation(object obj)
        {
            ContractClausesAdding ga = new ContractClausesAdding();

            ga.ShowDialog();
            RefreshData();
        }

        public RelayCommand EditCommand =>
            _editCommand ?? (_editCommand = new RelayCommand(EditImplementation, CanExecuteCommand));

        private void EditImplementation(object obj)
        {

            ContractClausesAdding ge = new ContractClausesAdding(SelectedContractClauses.TheContractClauses);
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

        private ContractClausesVM _selectedContractClauses;

        public ContractClausesVM SelectedContractClauses
        {
            get => _selectedContractClauses;
            set
            {
                _selectedContractClauses = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<ContractClausesVM> _contractClauses;

        public ObservableCollection<ContractClausesVM> ContractClauses
        {
            get => _contractClauses;
            set
            {
                _contractClauses = value;
                base.OnPropertyChanged();

            }
        }

        protected override void RefreshData()
        {
            ContractClauses.Clear();

            GetData();


        }

        protected async override void GetData()
        {
            db = new AisContext();



            ObservableCollection<ContractClausesVM> contractClausessTemp = new ObservableCollection<ContractClausesVM>();
            var _contractClausess = await
                (from g in db.ContractClauses

                 select g).ToListAsync();


            foreach (ContractClauses contractClauses in _contractClausess)
            {
                contractClausessTemp.Add(new ContractClausesVM() { TheContractClauses = contractClauses,LinePrice = contractClauses.GoodsQuantity * contractClauses.Good.SellingPrice});
            }

            ContractClauses = contractClausessTemp;

        }

        protected override void DeleteCurrent()
        {
            //TODO do something with number lines
            if (SelectedContractClauses != null)
            {
                db.ContractClauses.Remove(SelectedContractClauses.TheContractClauses);
                db.SaveChanges();
                base.RefreshData();
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedContractClauses != null;
        }

        public ContractClausesViewModel() : base()
        {


        }


    }
}
