using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels
{
    class CrudVMBase :INotifyPropertyChanged
    {

        protected AisContext db = new AisContext();

        

        protected CrudVMBase()
        {
            GetData();

        }

        protected virtual void CommitUpdates()
        {
        }
        protected virtual void DeleteCurrent()
        {
        }
        protected virtual void RefreshData()
        {
            GetData();
            
        }
        protected virtual void GetData()
        {
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
