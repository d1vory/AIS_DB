using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels.Contract__Clauses
{
    class ContractClausesVM:INotifyPropertyChanged
    {
        private ContractClauses _theContractClauses;

        public ContractClauses TheContractClauses
        {
            get => _theContractClauses;
            set { _theContractClauses = value; OnPropertyChanged(); }
        }


        public ContractClausesVM()
        {
            TheContractClauses = new ContractClauses();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
