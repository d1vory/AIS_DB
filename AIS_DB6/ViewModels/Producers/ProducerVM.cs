using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels.Producers
{
    class ProducerVM:INotifyPropertyChanged
    {
        private Producer _theProducer;

        public Producer TheProducer
        {
            get => _theProducer;
            set => _theProducer = value;
        }

        public ProducerVM()
        {
            TheProducer = new Producer();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
