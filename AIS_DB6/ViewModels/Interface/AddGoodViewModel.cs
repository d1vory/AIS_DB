using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Annotations;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.Interface
{
    class AddGoodViewModel:INotifyPropertyChanged
    {
        private double _goodsQuantity;

        public double GoodsQuantity
        {
            get => _goodsQuantity;
            set => _goodsQuantity = value;
        }

        private RelayCommand _saveCommand;

        private Window _thisWindow;

        public Window ThisWindow
        {
            get => _thisWindow;
            set => _thisWindow = value;
        }


        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return GoodsQuantity != 0;
        }

        private async void SaveImplementation(object obj)
        {
           
            ThisWindow.Close();
        }

        public AddGoodViewModel(Window w, GoodsInfo gi)
        {
            ThisWindow = w;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
