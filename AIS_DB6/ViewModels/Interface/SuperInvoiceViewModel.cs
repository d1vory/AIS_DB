using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Models;
using AIS_DB6.ViewModels.Invoices;

namespace AIS_DB6.ViewModels.Interface
{
    class SuperInvoiceViewModel:CrudVMBase
    {
        private ObservableCollection<SuperInvoice> _invoices;

        public ObservableCollection<SuperInvoice> Invoices
        {
            get => _invoices;
            set => _invoices = value;
        }


        protected async override void GetData()
        {
            db = new AisContext();



            ObservableCollection<SuperInvoice> invoicesTemp = new ObservableCollection<SuperInvoice>();
            var _invoices = await
                (from g in db.InvoiceLinesGoods

                    select g).ToListAsync();

            foreach (var v in _invoices)
            {
                invoicesTemp.Add(new SuperInvoice()
                {
                    GoodsName = v.Good.Name,GoodsPrice = v.Good.SellingPrice,GoodsQuantity = v.Quantity,GroupName = v.Good.GoodsGroup.Name,InvoiceId = v.InvoiceId, 
                    ProducerName = v.Good.Producer.Name
                });
            }


            var _works = await (from w in db.InvoiceLinesWork select w).ToListAsync();
            foreach (InvoiceLinesWork ilw in _works)
            {
               
            }

            //foreach (Invoice inv in _invoices)
            //{
            //    invoicesTemp.Add(new SuperInvoice(){GoodsName = });
            //}

            Invoices = invoicesTemp;

        }


    }
}
