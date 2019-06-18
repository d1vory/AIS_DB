using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;
using AIS_DB6.Views.Clients;
using AIS_DB6.Views.Tables;

namespace AIS_DB6.ViewModels.Clients
{
    class ClientViewModel:CrudVMBase
    {
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
       

        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddImplementation, (o => true)));

        private void AddImplementation(object obj)
        {
            ClientAdding ga = new ClientAdding();

            ga.ShowDialog();
            RefreshData();
        }

        public RelayCommand EditCommand =>
            _editCommand ?? (_editCommand = new RelayCommand(EditImplementation, CanExecuteCommand));

        private void EditImplementation(object obj)
        {

            ClientAdding ge = new ClientAdding(SelectedClient.TheClient);
            ge.ShowDialog();


            RefreshData();
        }

        public RelayCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteImplementation, CanExecuteCommand));

        private void DeleteImplementation(object obj)
        {
            try
            {
                DeleteCurrent();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            base.RefreshData();
        }

        private ClientVM _selectedClient;

        public ClientVM SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<ClientVM> _clients;

        public ObservableCollection<ClientVM> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                base.OnPropertyChanged();

            }
        }

        protected override void RefreshData()
        {
            Clients.Clear();

            GetData();


        }

        protected async override void GetData()
        {
            db = new AisContext();



            ObservableCollection<ClientVM> clientsTemp = new ObservableCollection<ClientVM>();
            var _clients = await
                (from g in db.Clients

                 select g).ToListAsync();


            foreach (Client client in _clients)
            {
                clientsTemp.Add(new ClientVM() { TheClient = client });
            }

            Clients = clientsTemp;

        }

        protected override void DeleteCurrent()
        {
            //TODO do something with number lines
            if (SelectedClient != null)
            {
                db.Clients.Remove(SelectedClient.TheClient);
                db.SaveChanges();
                base.RefreshData();
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedClient != null;
        }

        public ClientViewModel() : base()
        {


        }



    }
}
