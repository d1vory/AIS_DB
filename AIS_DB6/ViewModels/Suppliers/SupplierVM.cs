using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels.Suppliers
{
    class SupplierVM:INotifyPropertyChanged
    {

        private Supplier _theSupplier;

        public Supplier TheSupplier
        {
            get => _theSupplier;
            set => _theSupplier = value;
        }

        public SupplierVM() : base()
        {
            TheSupplier = new Supplier();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
