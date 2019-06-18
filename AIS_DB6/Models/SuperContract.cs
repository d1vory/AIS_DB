using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_DB6.Models
{
    class SuperContract
    {


        private int _contractId;

        public int ContractId
        {
            get => _contractId;
            set => _contractId = value;
        }

        private string _goodsName;

        public string GoodsName
        {
            get => _goodsName;
            set => _goodsName = value;
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

        private double _linePrice;

        public double LinePrice
        {
            get => _linePrice;
            set => _linePrice = value;
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

        private double _totalCost;

        public double TotalCost
        {
            get => _totalCost;
            set => _totalCost = value;
        }

    }
}
