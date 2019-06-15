using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels.Contracts
{
    class ContractVM:INotifyPropertyChanged
    {
        private Contract _theContract;

        public Contract TheContract
        {
            get => _theContract;
            set { _theContract = value; OnPropertyChanged(); }
        }


        public ContractVM()
        {
            TheContract = new Contract();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
