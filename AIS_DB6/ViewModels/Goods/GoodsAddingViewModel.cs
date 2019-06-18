using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            good.GoodsGroupId = SelectedGroupId.Id;
            good.ProducerId = SelectedProducerId.Id;
            good.Name = Name;
            good.Characteristics = Characteristics;
            good.SellingPrice = SellingPrice;
            good.GoodsGroup = db.GoodsGroup.Find(SelectedGroupId.Id);
            good.Producer = db.Producers.Find(SelectedProducerId.Id);
          

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

        private StrInt _selectedGroupId;

        public StrInt SelectedGroupId
        {
            get => _selectedGroupId;
            set => _selectedGroupId = value;
        }

        private StrInt _selectedProducerId;

        public StrInt SelectedProducerId
        {
            get => _selectedProducerId;
            set => _selectedProducerId = value;
        }


        private ObservableCollection<StrInt> _goodsGroupIds ;

        public ObservableCollection<StrInt> GoodsGroupIds
        {
            get => _goodsGroupIds;
            set => _goodsGroupIds = value;
        }



        private ObservableCollection<StrInt> _producerIds;

        public ObservableCollection<StrInt> ProducerIds
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

        protected override async void GetData()
        {

            GoodsGroupIds = new ObservableCollection<StrInt>();
            ProducerIds = new ObservableCollection<StrInt>();
            await Task.Run(() =>
            {
                foreach (Models.GoodsGroup gg in db.GoodsGroup)
                {
                    GoodsGroupIds.Add(new StrInt(gg.GoodsGroupId,gg.Name));
                }

                OnPropertyChanged();
                foreach (Producer pp in db.Producers)
                {
                    ProducerIds.Add(new StrInt(pp.ProducerId,pp.Name));
                }

               

            });



        }

        public GoodsAddingViewModel(Window w):base()
        {
          
            Thiswindow = w;
        }


    }
}
