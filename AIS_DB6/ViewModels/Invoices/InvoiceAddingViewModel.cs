using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.Invoices
{
    class InvoiceAddingViewModel:CrudVMBase
    {
        private RelayCommand _saveCommand;



        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return SelectedDate != null && SelectedClientId != 0;
        }

        private async void SaveImplementation(object obj)
        {

            Invoice inv =new Invoice();
            inv.InvoiceId = 0;
            inv.ClientId = SelectedClientId;
            inv.Date = SelectedDate;
            inv.Client = db.Clients.Find(SelectedClientId);

            db.Invoices.Add(inv);
            await db.SaveChangesAsync();

            Thiswindow.Close();
        }


        private Window _thiswindow;

        public Window Thiswindow
        {
            get => _thiswindow;
            set => _thiswindow = value;
        }


        private int _selectedClientId ;

        public int SelectedClientId
        {
            get => _selectedClientId;
            set
            {
                _selectedClientId = value; OnPropertyChanged();

            }
        }

        private List<int> _clientIds;

        public List<int> ClientIds
        {
            get => _clientIds;
            set
            {
                _clientIds = value;
                OnPropertyChanged();
            }
        }

        private DateTime _selectedDate = DateTime.Today;

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }




        protected async override void GetData()
        {
            await Task.Run(() =>
            {


                
                foreach (Client s in db.Clients)
                {
                    ClientIds.Add(s.ClientId);
                }

               

            });



        }

        public InvoiceAddingViewModel(Window w) : base()
        {

            ClientIds = new List<int>();
            Thiswindow = w;
        }

    }
}
