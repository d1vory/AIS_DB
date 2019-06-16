using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.Contract__Clauses
{
    class ContractClausesAddingViewModel:CrudVMBase

    {
        private RelayCommand _saveCommand;



        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return GoodsQuantity != 0;
        }

        private async void SaveImplementation(object obj)
        {
           
            ContractClauses cc = new ContractClauses();
            cc.ContractId = SelectedContractId;
            cc.GoodsId = SelectedGoodId;
            cc.GoodsQuantity = GoodsQuantity;
            cc.Good = db.Goods.Find(SelectedGoodId);
            cc.Contract = db.Contracts.Find(SelectedContractId);
            db.ContractClauses.Add(cc);

            await db.SaveChangesAsync();

            Thiswindow.Close();
        }


        private Window _thiswindow;

        public Window Thiswindow
        {
            get => _thiswindow;
            set => _thiswindow = value;
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

        private int _selectedContractId;

        public int SelectedContractId
        {
            get => _selectedContractId;
            set
            {
                _selectedContractId = value;
                OnPropertyChanged();
            }
        }


        private List<int> _goodIds;

        public List<int> GoodIds
        {
            get => _goodIds;
            set => _goodIds = value;
        }



        private List<int> _contractIds;

        public List<int> ContractIds
        {
            get => _contractIds;
            set => _contractIds = value;
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
                foreach (Contract pp in db.Contracts)
                {
                    ContractIds.Add(pp.ContractId);
                }

               
            });



        }

        public ContractClausesAddingViewModel(Window w) : base()
        {
            GoodIds = new List<int>();
            ContractIds = new List<int>();
            Thiswindow = w;
        }


    }
}
