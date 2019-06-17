using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Annotations;

namespace AIS_DB6.Models
{
    class GoodsInfo:INotifyPropertyChanged
    {
        private string _goodsName;

        public string GoodsName
        {
            get => _goodsName;
            set => _goodsName = value;
        }

        private string _producerName;

        public string ProducerName
        {
            get => _producerName;
            set => _producerName = value;
        }

        private string _groupName;

        public string GroupName
        {
            get => _groupName;
            set => _groupName = value;
        }

      

 

        public double LinePrice
        {
            get { return GoodsQuantity * GoodsPrice; }

        }

        private double _goodsPrice;

        public double GoodsPrice
        {
            get => _goodsPrice;
            set => _goodsPrice = value;
        }

        private int _goodsQuantity;

        public int GoodsQuantity
        {
            get => _goodsQuantity;
            set => _goodsQuantity = value;
        }

        private int _goodsId;

        public int GoodsId
        {
            get => _goodsId;
            set => _goodsId = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
