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
using AIS_DB6.Views.Interface;
using AIS_DB6.Views.Suppliers;
using AIS_DB6.Views.Tables;

namespace AIS_DB6.ViewModels.Interface
{
    class ConclusionContractViewModel:CrudVMBase
    {
        private ObservableCollection<GoodsInfo> _goodsChoosing;

        public ObservableCollection<GoodsInfo> GoodsChoosing
        {
            get => _goodsChoosing;
            set => _goodsChoosing = value;
        }

        private GoodsInfo _selectedChoosingGood;

        public GoodsInfo SelectedChoosingGood
        {
            get => _selectedChoosingGood;
            set => _selectedChoosingGood = value;
        }

        private ObservableCollection<GoodsInfo> _addedGoods;

        public ObservableCollection<GoodsInfo> AddedGoods
        {
            get => _addedGoods;
            set => _addedGoods = value;
        }

        private GoodsInfo _selectedAddedGood;

        public GoodsInfo SelectedAddedGood
        {
            get => _selectedAddedGood;
            set => _selectedAddedGood = value;
        }

        private ObservableCollection<StrInt> _supplierIds;

        public ObservableCollection<StrInt> SupplierIds
        {
            get => _supplierIds;
            set => _supplierIds = value;
        }

        private StrInt _selectedSupplierId;

        public StrInt SelectedSupplierId
        {
            get => _selectedSupplierId;
            set
            {
                _selectedSupplierId = value;
                OnPropertyChanged();

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


        private double _totalCost;
        public double TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; OnPropertyChanged(); }

        }



        private RelayCommand _addGood;
        public RelayCommand AddGoodCommand => _addGood ?? (_addGood = new RelayCommand(AddGoodImpl, CanExecuteGoodAdding));

        private bool CanExecuteGoodAdding(object arg)
        {
            return SelectedChoosingGood != null;
        }

        private void AddGoodImpl(object obj)
        {
            var gq = new AddGoodWindow();


            if (gq.ShowDialog() == true)
            {

                GoodsInfo gi = new GoodsInfo()
                {
                    GoodsId = SelectedChoosingGood.GoodsId,
                    GoodsName = SelectedChoosingGood.GoodsName,
                    GoodsPrice = SelectedChoosingGood.GoodsPrice,
                    GoodsQuantity = Convert.ToInt32(gq.ResponseText),
                    GroupName = SelectedChoosingGood.GroupName,
                    ProducerName = SelectedChoosingGood.ProducerName
                };

                AddedGoods.Add(gi);
                TotalCost += gi.LinePrice;

            }
        }

        private RelayCommand _newClientCommand;

        public RelayCommand NewClientCommand =>
            _newClientCommand ?? (_newClientCommand = new RelayCommand(NewClientImpl, (o) => true));

        private void NewClientImpl(object obj)
        {
            //TODO list doesnt update
            SupplierAdding ca = new SupplierAdding();
            ca.ShowDialog();
            RefreshData();
        }

        private RelayCommand _deleteCommand;

        public RelayCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteImplementation, CanExecuteGoodRemoving));

        private bool CanExecuteGoodRemoving(object arg)
        {
            return SelectedAddedGood != null;
        }

        private void DeleteImplementation(object obj)
        {
            try
            {
                AddedGoods.Remove(SelectedAddedGood);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            base.RefreshData();
        }

        private RelayCommand _addNewGoodCommand;

        public RelayCommand AddNewGoodCommand =>
            _addNewGoodCommand ?? (_addNewGoodCommand = new RelayCommand(AddNewGoodImpl, (o) => true));

        private void AddNewGoodImpl(object obj)
        {
           
            GoodsAdding  ga = new GoodsAdding();
            ga.ShowDialog();
            RefreshData();
        }


        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return AddedGoods.Count > 0 && SelectedSupplierId != null && SelectedSignDate < SelectedTerminationDate;
        }


        private  void SaveImplementation(object obj)
        {
           Contract ct = new Contract();
           ct.ContractId = 0;
           ct.SignDate = SelectedSignDate;
           ct.TerminationDate = SelectedTerminationDate;
           ct.SupplierId = SelectedSupplierId.Id;
           ct.Supplier = db.Suppliers.Find(SelectedSupplierId.Id);
           
           List<ContractClauses> ccl = new List<ContractClauses>();
           ContractClauses temp;
           foreach (GoodsInfo gg in AddedGoods)
           {
               temp = new ContractClauses()
               {
                   ContractId = ct.ContractId, Contract = ct, GoodsId = gg.GoodsId, Good = db.Goods.Find(gg.GoodsId),
                   GoodsQuantity = gg.GoodsQuantity
               };
               db.ContractClauses.Add(temp);
               ccl.Add(temp);
           }

           ct.ContractClauses = ccl;
           db.SaveChanges();

           MessageBox.Show("Договiр додано");
            AddedGoods.Clear();
            SelectedSignDate = DateTime.Today;
            SelectedTerminationDate = DateTime.Today;
            TotalCost = 0;

        }

        protected async override void GetData()
        {
            db = new AisContext();

            SupplierIds = new ObservableCollection<StrInt>();

            foreach (Supplier cl in db.Suppliers)
            {
                SupplierIds.Add(new StrInt(cl.SupplierId, cl.Surname + " " + cl.Name));
            }

            ObservableCollection<GoodsInfo> temp = new ObservableCollection<GoodsInfo>();

            var _goods = await
                (from g in db.Goods

                    select g).ToListAsync();

            foreach (Good g in _goods)
            {
                temp.Add(new GoodsInfo()
                {
                    GoodsName = g.Name,
                    GoodsPrice = g.SellingPrice,
                    GroupName = g.GoodsGroup.Name,
                    ProducerName = g.Producer.Name,
                    GoodsId = g.GoodsId
                });

            }

            GoodsChoosing = temp;

        }

        public ConclusionContractViewModel()
        {
            AddedGoods = new ObservableCollection<GoodsInfo>();

        }
    }
}
