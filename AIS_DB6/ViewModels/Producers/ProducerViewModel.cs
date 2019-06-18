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
using AIS_DB6.Views.Producers;
using AIS_DB6.Views.Tables;

namespace AIS_DB6.ViewModels.Producers
{
    class ProducerViewModel : CrudVMBase
    {
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
       

        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddImplementation, (o => true)));

        private void AddImplementation(object obj)
        {
            ProducerAdding pa = new ProducerAdding();
            //ga.ShowDialog();
            pa.ShowDialog();
            RefreshData();
        }

        public RelayCommand EditCommand =>
            _editCommand ?? (_editCommand = new RelayCommand(EditImplementation, CanExecuteCommand));

        private void EditImplementation(object obj)
        {

            ProducerAdding pe = new ProducerAdding(SelectedProducer.TheProducer);
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

        private ProducerVM _selectedProducer;

        public ProducerVM SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<ProducerVM> _producers;

        public ObservableCollection<ProducerVM> Producers
        {
            get => _producers;
            set
            {
                _producers = value;
                base.OnPropertyChanged();

            }
        }

        protected override void RefreshData()
        {
            Producers.Clear();

            GetData();


        }

        protected async override void GetData()
        {
            db = new AisContext();



            ObservableCollection<ProducerVM> producersTemp = new ObservableCollection<ProducerVM>();
            var _producers = await
                (from g in db.Producers

                 select g).ToListAsync();


            foreach (Producer producer in _producers)
            {
                producersTemp.Add(new ProducerVM() { TheProducer = producer });
            }

            Producers = producersTemp;

        }

        protected override void DeleteCurrent()
        {
            //TODO do something with number lines
            if (SelectedProducer != null)
            {
                db.Producers.Remove(SelectedProducer.TheProducer);
                db.SaveChanges();
                base.RefreshData();
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedProducer != null;
        }

        public ProducerViewModel() : base()
        {


        }
    }
}
