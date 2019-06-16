using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels.Invoice__lines_Work
{
    class InvoiceLinesWorkVM:INotifyPropertyChanged
    {
        private InvoiceLinesWork _theInvoiceLinesWork;

        public InvoiceLinesWork TheInvoiceLinesWork
        {
            get => _theInvoiceLinesWork;
            set => _theInvoiceLinesWork = value;
        }

        public InvoiceLinesWorkVM()
        {
            TheInvoiceLinesWork = new InvoiceLinesWork();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
