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
    class ContractClausesEditingViewModel:CrudVMBase
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
            ContractClauses cc = db.ContractClauses.SingleOrDefault(c =>
                c.ContractId == SelectedContractId && c.GoodsId == SelectedGoodId);

            if (cc != null)
            {
                cc.ContractId = SelectedContractId;
                cc.GoodsId = SelectedGoodId;
                cc.GoodsQuantity = GoodsQuantity;
                cc.Good = db.Goods.Find(SelectedGoodId);
                cc.Contract = db.Contracts.Find(SelectedContractId);
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

        private int _selectedGroupId = 1;

        public int SelectedGroupId
        {
            get => _selectedGroupId;
            set
            {
                _selectedGroupId = value;
                OnPropertyChanged();
            }
        }

        private int _selectedProducerId = 1;

        public int SelectedProducerId
        {
            get => _selectedProducerId;
            set
            {
                _selectedProducerId = value;
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

        public ContractClausesEditingViewModel(Window w, ContractClauses cc) : base()
        {
            GoodIds = new List<int>();
            ContractIds = new List<int>();
            Thiswindow = w;

            GoodsQuantity = cc.GoodsQuantity;
            SelectedContractId = cc.ContractId;
            SelectedGoodId = cc.GoodsId;

            
        }
    }
}
