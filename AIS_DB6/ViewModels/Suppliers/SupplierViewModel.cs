using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

using AIS_DB6.Views.Suppliers;

namespace AIS_DB6.ViewModels.Suppliers
{
    class SupplierViewModel:CrudVMBase
    {
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
        

        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddImplementation, (o => true)));

        private void AddImplementation(object obj)
        {
            SupplierAdding sa = new SupplierAdding();
            
            sa.ShowDialog();
            RefreshData();
        }

        public RelayCommand EditCommand =>
            _editCommand ?? (_editCommand = new RelayCommand(EditImplementation, CanExecuteCommand));

        private void EditImplementation(object obj)
        {

            SupplierAdding pe = new SupplierAdding(SelectedSupplier.TheSupplier);
            pe.ShowDialog();





            RefreshData();
        }

        public RelayCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteImplementation, CanExecuteCommand));

        private void DeleteImplementation(object obj)
        {
            try
            {
                DeleteCurrent();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            base.RefreshData();
        }

        private SupplierVM _selectedSupplier;

        public SupplierVM SelectedSupplier
        {
            get => _selectedSupplier;
            set
            {
                _selectedSupplier = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<SupplierVM> _suppliers;

        public ObservableCollection<SupplierVM> Suppliers
        {
            get => _suppliers;
            set
            {
                _suppliers = value;
                base.OnPropertyChanged();

            }
        }

        protected override void RefreshData()
        {
            Suppliers.Clear();

            GetData();


        }

        protected async override void GetData()
        {
            db = new AisContext();



            ObservableCollection<SupplierVM> supplierssTemp = new ObservableCollection<SupplierVM>();
            var _suppliers = await
                (from g in db.Suppliers

                 select g).ToListAsync();


            foreach (Supplier sup in _suppliers)
            {
                supplierssTemp.Add(new SupplierVM() { TheSupplier = sup });
            }

            Suppliers = supplierssTemp;

        }

        protected override void DeleteCurrent()
        {
            //TODO do something with number lines
            if (SelectedSupplier != null)
            {
                db.Suppliers.Remove(SelectedSupplier.TheSupplier);
                db.SaveChanges();
                base.RefreshData();
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedSupplier != null;
        }

        public SupplierViewModel() : base()
        {


        }
    }
}
