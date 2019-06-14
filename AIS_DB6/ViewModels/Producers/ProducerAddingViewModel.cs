using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.Producers
{
    class ProducerAddingViewModel:CrudVMBase
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

            Producer producer = new Producer();
            producer.ProducerId = 0;
            
            producer.Name = Name;
            producer.UserExpierence = UserExpierence ;
           

            db.Producers.Add(producer);
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

        private double _sellingPrice;

        public double SellingPrice
        {
            get => _sellingPrice;
            set => _sellingPrice = value;
        }

        private string _userExpierence;

        public string UserExpierence
        {
            get => _userExpierence;
            set => _userExpierence = value;
        }

        protected async override void GetData()
        {
            


        }

        public ProducerAddingViewModel(Window w) : base()
        {
            Thiswindow = w;
        }

       

    }
}
