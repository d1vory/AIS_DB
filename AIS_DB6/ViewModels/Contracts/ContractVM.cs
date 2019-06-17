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

        private int _duration;

        public int Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }


        private double _totalCost;

        public double TotalCost
        {
            get => _totalCost;
            set
            {
                _totalCost = value;
                OnPropertyChanged();
            }
        }

        double CalculateTotalCost()
        {
            double res = 0;
            foreach (ContractClauses cc in TheContract.ContractClauses)
            {
                res += cc.GoodsQuantity * cc.Good.SellingPrice;
            }

            return res;
        }


        public ContractVM()
        {
            TheContract = new Contract();
            TotalCost = CalculateTotalCost();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
