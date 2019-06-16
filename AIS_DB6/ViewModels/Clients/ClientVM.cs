using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels.Clients
{
    class ClientVM:INotifyPropertyChanged
    {
        private Client _theClient;

        public Client TheClient
        {
            get => _theClient;
            set { _theClient = value; OnPropertyChanged(); }
        }


        public ClientVM()
        {
            TheClient = new Client();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
