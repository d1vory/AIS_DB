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
using AIS_DB6.Views.Clients;
using AIS_DB6.Views.Interface;
using AIS_DB6.Views.Invoice__lines_Work;

namespace AIS_DB6.ViewModels.Interface
{
    class PurchaseViewModel:CrudVMBase
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



        private ObservableCollection<StrInt> _clientIds;

        public ObservableCollection<StrInt> ClientIds
        {
            get => _clientIds;
            set => _clientIds = value;
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        private string _typeOfWork;

        public string TypeOfWork
        {
            get => _typeOfWork;
            set => _typeOfWork = value;
        }

        private double _workCost;

        public double WorkCost
        {
            get => _workCost;
            set => _workCost = value;
        }

        private int _workerId;

        public int WorkerId
        {
            get => _workerId;
            set => _workerId = value;
        }

        private double _totalCost;
        public double TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value;OnPropertyChanged(); }

        }

        private bool _isWorkAdded;

        public bool IsWorkAdded
        {
            get => _isWorkAdded;
            set => _isWorkAdded = value;
        }

        private StrInt _selectedClientId;

        public StrInt SelectedClientId
        {
            get => _selectedClientId;
            set
            {
                _selectedClientId = value;
                OnPropertyChanged();
                
            }
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
            ClientAdding ca = new ClientAdding();
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

        private RelayCommand _addWorkCommand;

        public RelayCommand AddWorkCommand =>
            _addWorkCommand ?? (_addWorkCommand = new RelayCommand(AddWorkImpl, (o) => true));

        private void AddWorkImpl(object obj)
        {
            InvoiceLinesWorkAdding ilwa = new InvoiceLinesWorkAdding();
            if (ilwa.ShowDialog() == true)
            {
                WorkCost = Convert.ToDouble(ilwa.WorkCost);
                if (ilwa.StartDate.HasValue)
                {
                    StartDate = ilwa.StartDate.Value;
                }
                
                TypeOfWork = ilwa.WorkType;
                WorkerId = ilwa.WorkerId;
                MessageBox.Show(StartDate.ToShortDateString());
                TotalCost += WorkCost;
                IsWorkAdded = true;
            }

        }


        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return AddedGoods.Count > 0 && SelectedClientId != null;
        }


        private async void SaveImplementation(object obj)
        {
            Invoice inv = new Invoice();
            inv.InvoiceId = 0;
            inv.Date = DateTime.Today;
            inv.ClientId = SelectedClientId.Id;
            inv.Client = db.Clients.Find(SelectedClientId.Id);
           

            List < InvoiceLinesGoods > ilg = new List<InvoiceLinesGoods>();
            InvoiceLinesGoods temp;
            foreach (GoodsInfo gg in AddedGoods)
            {
                temp = new InvoiceLinesGoods()
                {
                    GoodsId = gg.GoodsId, InvoiceId = inv.InvoiceId,
                    Good = db.Goods.Find(gg.GoodsId), Invoice = inv, Quantity = gg.GoodsQuantity
                };
                db.InvoiceLinesGoods.Add(temp);
                ilg.Add(temp);
            }

            inv.InvoiceLinesGoods = ilg;


            if (IsWorkAdded)
            {
                InvoiceLinesWork ilw = new InvoiceLinesWork();
                ilw.InvoiceId = inv.InvoiceId;
                ilw.WorkerId = WorkerId;
                ilw.StartDate = StartDate;
                ilw.WorkCost = WorkCost;
                ilw.TypeOfWork = TypeOfWork;
                ilw.Invoice = inv;
                ilw.Worker = db.Workers.Find(WorkerId);
                db.InvoiceLinesWork.Add(ilw);

                inv.InvoiceLinesWork = new List<InvoiceLinesWork>();
                inv.InvoiceLinesWork.Add(ilw);
               
            }

            db.Invoices.Add(inv);
            db.SaveChanges();

        }

        protected override void RefreshData()
        {
           
            
            base.RefreshData();
        }


        protected async override void GetData()
        {
            db = new AisContext();

            ClientIds = new ObservableCollection<StrInt>();

            foreach (Client cl in db.Clients)
            {
                ClientIds.Add(new StrInt(cl.ClientId,cl.Surname + " " + cl.Name));
            }

            ObservableCollection<GoodsInfo> temp = new ObservableCollection<GoodsInfo>();

            var _goods = await
                (from g in db.Goods

                    select g).ToListAsync();

            foreach (Good g in _goods)
            {
                temp.Add(new GoodsInfo() { GoodsName = g.Name, GoodsPrice = g.SellingPrice,
                    GroupName = g.GoodsGroup.Name,ProducerName = g.Producer.Name,GoodsId = g.GoodsId});

            }

            GoodsChoosing = temp;

        }

        public PurchaseViewModel()
        {
            AddedGoods = new ObservableCollection<GoodsInfo>();
            
        }
    }
}
