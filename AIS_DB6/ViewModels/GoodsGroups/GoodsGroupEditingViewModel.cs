using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.GoodsGroups
{
    class GoodsGroupEditingViewModel:CrudVMBase
    {

        private RelayCommand _saveCommand;



        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return _name != null;
        }

        private void SaveImplementation(object obj)
        {


            GoodsGroup goodGroup = db.GoodsGroup.SingleOrDefault(g => g.GoodsGroupId == GoodsGroupId);
            if (goodGroup != null)
            {

                goodGroup.Description = Characteristics;
                goodGroup.Name = Name;
                db.SaveChanges();

            }

            Thiswindow.Close();
        }




        private Window _thiswindow;

        public Window Thiswindow
        {
            get => _thiswindow;
            set => _thiswindow = value;
        }

        private int _goodsGroupId;

        public int GoodsGroupId
        {
            get => _goodsGroupId;
            set => _goodsGroupId = value;
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

      

        public GoodsGroupEditingViewModel(Window w, GoodsGroup g) : base()
        {

            Thiswindow = w;


            Name = g.Name;

            Characteristics = g.Description;

        }
    }
}
