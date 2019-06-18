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
using AIS_DB6.Views.GoodsGroups;

namespace AIS_DB6.ViewModels.GoodsGroups
{
    class GoodsGroupViewModel:CrudVMBase
    {

        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
       


        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddImplementation, (o => true)));

        private void AddImplementation(object obj)
        {
            GoodsGroupAdding gga = new GoodsGroupAdding();
            //ga.ShowDialog();
            gga.ShowDialog();
            RefreshData();
        }

        public RelayCommand EditCommand =>
           _editCommand ?? (_editCommand = new RelayCommand(EditImplementation, CanExecuteCommand));

        private void EditImplementation(object obj)
        {

            GoodsGroupAdding ge = new GoodsGroupAdding(SelectedGoodsGroup.TheGoodsGroup);
            ge.ShowDialog();

           

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

        private GoodsGroupVM _selectedGoodsGroup;

        public GoodsGroupVM SelectedGoodsGroup
        {
            get => _selectedGoodsGroup;
            set
            {
                _selectedGoodsGroup = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<GoodsGroupVM> _goodGroupses;

        public ObservableCollection<GoodsGroupVM> GoodsGroups
        {
            get => _goodGroupses;
            set
            {
                _goodGroupses = value;
                base.OnPropertyChanged();

            }
        }

        protected override void RefreshData()
        {
            GoodsGroups.Clear();

            GetData();


        }

        protected async override void GetData()
        {
            db = new AisContext();

            ObservableCollection<GoodsGroupVM> goodsTemp = new ObservableCollection<GoodsGroupVM>();
            var _goodGroups = await
                (from gg in db.GoodsGroup

                 select gg).ToListAsync();


            foreach (GoodsGroup goodGroup in _goodGroups)
            {
                
                goodsTemp.Add(new GoodsGroupVM() { TheGoodsGroup = goodGroup });
            }

            GoodsGroups = goodsTemp;

        }

        protected override void DeleteCurrent()
        {
            //TODO do something with number lines
            if (SelectedGoodsGroup != null)
            {
                db.GoodsGroup.Remove(SelectedGoodsGroup.TheGoodsGroup);
                db.SaveChanges();
                base.RefreshData();
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedGoodsGroup != null;
        }

        public GoodsGroupViewModel() : base()
        {


        }


    }
}
