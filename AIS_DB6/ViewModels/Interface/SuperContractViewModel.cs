using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.Interface
{
    class SuperContractViewModel:CrudVMBase
    {
        private ObservableCollection<SuperContract> _contracts;

        public ObservableCollection<SuperContract> Contracts
        {
            get => _contracts;
            set => _contracts = value;
        }


        protected async override void GetData()
        {
            db = new AisContext();
            ObservableCollection<SuperContract> contactsTemp = new ObservableCollection<SuperContract>();
            var _contracts = await (from g in db.ContractClauses select g).ToListAsync();

            foreach (ContractClauses v in _contracts)
            {
                contactsTemp.Add(new SuperContract()
                {
                    GoodsName = v.Good.Name,
                    GoodsPrice = v.Good.SellingPrice,
                    GoodsQuantity = v.GoodsQuantity,
                    GroupName = v.Good.GoodsGroup.Name,
                    ContractId = v.ContractId,
                    ProducerName = v.Good.Producer.Name,LinePrice = v.GoodsQuantity* v.Good.SellingPrice
                });
            }

          
            Contracts = contactsTemp;

        }

    }
}
