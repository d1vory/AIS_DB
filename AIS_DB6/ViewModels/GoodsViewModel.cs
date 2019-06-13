using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Annotations;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels
{
    class GoodsViewModel:CrudVMBase
    {
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
        private RelayCommand _printCommand;


        public RelayCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteImplementation, CanExecuteCommand));

        private void DeleteImplementation(object obj)
        {
            try
            {
                DeleteCurrent();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private GoodVM _selectedGood;

        public GoodVM SelectedGood
        {
            get => _selectedGood;
            set
            {
                _selectedGood = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<GoodVM> _goods;

        public ObservableCollection<GoodVM> Goods
        {
            get => _goods;
            set
            {
                _goods = value;
                base.OnPropertyChanged();
              
            }
        }

        protected async override void GetData()
        {

            ObservableCollection<GoodVM> goodsTemp = new ObservableCollection<GoodVM>();
            var _goods = await
                (from g in db.Goods
                 orderby g.GoodsId
                 select g).ToListAsync();


            foreach (Good good in _goods)
            {
                goodsTemp.Add(new GoodVM(){TheGood = good});
            }

            Goods = goodsTemp;
        }

        protected override void DeleteCurrent()
        {
            //TODO do something with number lines
            if (SelectedGood != null)
            {
                db.Goods.Remove(SelectedGood.TheGood);
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedGood != null;
        }

        public GoodsViewModel(): base()
        {
           

        }


      
    }
}
