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
    class ProducerEditingViewModel : CrudVMBase
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


            Producer producer = db.Producers.SingleOrDefault(g => g.ProducerId == ProducerId);
            if (producer != null)
            {
                
                producer.ProducerId = ProducerId;
                producer.Name = Name;
                producer.UserExpierence = UserExpierence;
                
                db.SaveChanges();

            }


            Thiswindow.Close();
        }

        private int _producerId;

        public int ProducerId
        {
            get => _producerId;
            set => _producerId = value;
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
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _userExpierence;

        public string UserExpierence
        {
            get => _userExpierence;
            set
            {
                _userExpierence = value;
                OnPropertyChanged();
            }
        }

        protected async override void GetData()
        {
           

        }

        public ProducerEditingViewModel(Window w, Producer p) : base()
        {
            
            Thiswindow = w;

            ProducerId = p.ProducerId;
            Name = p.Name;
            UserExpierence = p.UserExpierence;
            
        }
    }
}

