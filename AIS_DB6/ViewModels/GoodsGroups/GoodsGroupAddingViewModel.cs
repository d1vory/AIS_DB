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
    class GoodsGroupAddingViewModel:CrudVMBase
    {
        private RelayCommand _saveCommand;



        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return _name != null;
        }

        private async void SaveImplementation(object obj)
        {

            GoodsGroup goodGroup = new GoodsGroup();
            goodGroup.GoodsGroupId = 0;
            goodGroup.Description = Characteristics;
            goodGroup.Name = Name;

            db.GoodsGroup.Add(goodGroup);
            await db.SaveChangesAsync();

            Thiswindow.Close();
        }


        private Window _thiswindow;

        public Window Thiswindow
        {
            get => _thiswindow;
            set => _thiswindow = value;
        }



        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }



        private string _characteristics;

        public string Characteristics
        {
            get => _characteristics;
            set => _characteristics = value;
        }

       

        public GoodsGroupAddingViewModel(Window w) : base()
        {
            Thiswindow = w;
        }
    }
}
