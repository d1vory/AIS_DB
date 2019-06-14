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
    class SupplierAddingViewModel:CrudVMBase
    {
        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return _name != null;
        }

        private async void SaveImplementation(object obj)
        {

            Supplier supplier = new Supplier();
            supplier.SupplierId = 0;

            supplier.Name = Name;
            supplier.Patronym = Patronym;
            supplier.Surname = Surname;


            db.Suppliers.Add(supplier);
            await db.SaveChangesAsync();

            Thiswindow.Close();
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
            set => _name = value;
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
       


        public SupplierAddingViewModel(Window w) : base()
        {
            Thiswindow = w;
        }

    }
}
