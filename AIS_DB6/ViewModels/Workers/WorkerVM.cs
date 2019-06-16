using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels.Workers
{
    class WorkerVM:INotifyPropertyChanged
    {
        private Worker _theWorker;

        public Worker TheWorker
        {
            get => _theWorker;
            set => _theWorker = value;
        }

        public WorkerVM() : base()
        {
            TheWorker = new Worker();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
