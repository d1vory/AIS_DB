using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels
{
    public class GoodsAddingViewModel:CrudVMBase
    {
        private RelayCommand _saveCommand;
        

       
        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return  _name != null ;
        }

        private async void SaveImplementation(object obj)
        {

            Good good = new Good();
            good.GoodsId = 0;
            good.GoodsGroupId = SelectedGroupId;
            good.ProducerId = SelectedProducerId;
            good.Name = Name;
            good.Characteristics = Characteristics;
            good.SellingPrice = SellingPrice;
            good.GoodsGroup = db.GoodsGroup.Find(SelectedGroupId);
            good.Producer = db.Producers.Find(SelectedProducerId);
          

            db.Goods.Add(good);
            await db.SaveChangesAsync();

            Thiswindow.Close();
        }


        private Window _thiswindow;

        public Window Thiswindow
        {
            get => _thiswindow;
            set => _thiswindow = value;
        }

        private int _selectedGroupId;

        public int SelectedGroupId
        {
            get => _selectedGroupId;
            set => _selectedGroupId = value;
        }

        private int _selectedProducerId;

        public int SelectedProducerId
        {
            get => _selectedProducerId;
            set => _selectedProducerId = value;
        }


        private List<int> _goodsGroupIds ;

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
            set => _name = value;
        }

        private double _sellingPrice;

        public double SellingPrice
        {
            get => _sellingPrice;
            set => _sellingPrice = value;
        }

        private string _characteristics;

        public string Characteristics
        {
            get => _characteristics;
            set => _characteristics = value;
        }

        protected async override void GetData()
        {
            await Task.Run(() =>
            {
                foreach (Models.GoodsGroup gg in db.GoodsGroup)
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

        public GoodsAddingViewModel(Window w):base()
        {
            GoodsGroupIds = new List<int>();
            ProducerIds = new List<int>();
            Thiswindow = w;
        }


    }
}
