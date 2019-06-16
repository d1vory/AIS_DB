using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels.Invoices
{
    class InvoiceVM:INotifyPropertyChanged
    {

        private Invoice _theInvoice;

        public Invoice TheInvoice
        {
            get => _theInvoice;
            set { _theInvoice = value; OnPropertyChanged(); }
        }


        public InvoiceVM()
        {
            TheInvoice = new Invoice();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
