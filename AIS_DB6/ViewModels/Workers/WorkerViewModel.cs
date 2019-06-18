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
using AIS_DB6.Views.Workers;

namespace AIS_DB6.ViewModels.Workers
{
    class WorkerViewModel:CrudVMBase
    {
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
       

        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddImplementation, (o => true)));

        private void AddImplementation(object obj)
        {
            WorkerAdding sa = new WorkerAdding();

            sa.ShowDialog();
            RefreshData();
        }

        public RelayCommand EditCommand =>
            _editCommand ?? (_editCommand = new RelayCommand(EditImplementation, CanExecuteCommand));

        private void EditImplementation(object obj)
        {

            WorkerAdding pe = new WorkerAdding(SelectedWorker.TheWorker);
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

        private WorkerVM _selectedWorker;

        public WorkerVM SelectedWorker
        {
            get => _selectedWorker;
            set
            {
                _selectedWorker = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<WorkerVM> _workers;

        public ObservableCollection<WorkerVM> Workers
        {
            get => _workers;
            set
            {
                _workers = value;
                base.OnPropertyChanged();

            }
        }

        protected override void RefreshData()
        {
            Workers.Clear();

            GetData();


        }

        protected async override void GetData()
        {
            db = new AisContext();



            ObservableCollection<WorkerVM> workerssTemp = new ObservableCollection<WorkerVM>();
            var _workers = await
                (from g in db.Workers

                 select g).ToListAsync();


            foreach (Worker sup in _workers)
            {
                workerssTemp.Add(new WorkerVM() { TheWorker = sup });
            }

            Workers = workerssTemp;

        }

        protected override void DeleteCurrent()
        {
            
            if (SelectedWorker != null)
            {
                db.Workers.Remove(SelectedWorker.TheWorker);
                db.SaveChanges();
                base.RefreshData();
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedWorker != null;
        }

        public WorkerViewModel() : base()
        {


        }

    }
}
