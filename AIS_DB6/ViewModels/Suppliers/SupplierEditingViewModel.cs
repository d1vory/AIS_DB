using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.Suppliers
{
    class SupplierEditingViewModel:CrudVMBase
    {
        private RelayCommand _saveCommand;



        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return _name != null;
        }

        private void SaveImplementation(object obj)
        {


            Supplier supplier = db.Suppliers.SingleOrDefault(g => g.SupplierId == SupplierId);
            if (supplier != null)
            {

                //supplier.SupplierId = SupplierId;
                supplier.Name = Name;
                supplier.Patronym = Patronym;
                supplier.Surname = Surname;

                db.SaveChanges();

            }


            Thiswindow.Close();
        }

        private int _supplierId;

        public int SupplierId
        {
            get => _supplierId;
            set => _supplierId = value;
        }


        private Window _thiswindow;

        public Window Thiswindow
        {
            get => _thiswindow;
            set => _thiswindow = value;
        }


        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _patronym;

        public string Patronym
        {
            get => _patronym;
            set => _patronym = value;
        }

        private string _surname;

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }



        public SupplierEditingViewModel(Window w, Supplier p) : base()
        {

            Thiswindow = w;

            SupplierId = p.SupplierId;
            Name = p.Name;
            Surname = p.Surname;
            Patronym = p.Patronym;

        }

    }
}
