using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.Goods
{
    class GoodsEditingViewModel:CrudVMBase
    {
        private RelayCommand _saveCommand;



        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return _name != null;
        }

        private  void SaveImplementation(object obj)
        {
         

            Good good = db.Goods.SingleOrDefault(g => g.GoodsId == GoodId);
            if (good != null)
            {
                good.GoodsGroupId = SelectedGroupId;
                good.ProducerId = SelectedProducerId;
                good.Name = Name;
                good.Characteristics = Characteristics;
                good.SellingPrice = SellingPrice;
                good.GoodsGroup = db.GoodsGroup.Find(SelectedGroupId);
                good.Producer = db.Producers.Find(SelectedProducerId);
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


        private List<int> _goodsGroupIds;

        public List<int> GoodsGroupIds
        {
            get => _goodsGroupIds;
            set => _goodsGroupIds = value;
        }



        private List<int> _producerIds;

        public List<int> ProducerIds
        {
            get => _producerIds;
            set => _producerIds = value;
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private double _sellingPrice;

        public double SellingPrice
        {
            get => _sellingPrice;
            set
            {
                _sellingPrice = value;
                OnPropertyChanged();
            }
        }

        private string _characteristics;

        public string Characteristics
        {
            get => _characteristics;
            set
            {
                _characteristics = value;
                OnPropertyChanged();
            }
        }

        protected async override void GetData()
        {
            await Task.Run(() =>
            {
                foreach (GoodsGroup gg in db.GoodsGroup)
                {
                    GoodsGroupIds.Add(gg.GoodsGroupId);
                }

                OnPropertyChanged();
                foreach (Producer pp in db.Producers)
                {
                    ProducerIds.Add(pp.ProducerId);
                }

                OnPropertyChanged();

            });

        }

        public GoodsEditingViewModel(Window w, Good g) : base()
        {
            GoodsGroupIds = new List<int>();
            ProducerIds = new List<int>();
            Thiswindow = w;
            

            Name = g.Name;
            SelectedGroupId = g.GoodsGroupId;
            SelectedProducerId = g.ProducerId;
            Characteristics = g.Characteristics;
            SellingPrice = g.SellingPrice;
            GoodId = g.GoodsId;
        }
    }
}
