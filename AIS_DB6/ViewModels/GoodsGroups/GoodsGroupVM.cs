using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels.GoodsGroups
{
    class GoodsGroupVM:INotifyPropertyChanged
    {
        private GoodsGroup _theGoodsGroup;

        public GoodsGroup TheGoodsGroup
        {
            get => _theGoodsGroup;
            set { _theGoodsGroup = value; OnPropertyChanged(); }
        }

        public GoodsGroupVM()
        {
            TheGoodsGroup = new GoodsGroup();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
