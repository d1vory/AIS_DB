using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.Workers
{
    class WorkerEditingViewModel:CrudVMBase
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


            Worker wk = db.Workers.SingleOrDefault(g => g.WorkerId == WorkerId);
            if (wk != null)
            {

                wk.Name = Name;
                wk.Patronym = Patronym;
                wk.Surname = Surname;
                wk.Telephone = Telephone;
                wk.Speciality = Speciality;

                db.SaveChanges();

            }


            Thiswindow.Close();
        }

        private int _supplierId;

        public int WorkerId
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

        private string _telephone;

        public string Telephone
        {
            get => _telephone;
            set => _telephone = value;
        }

        private string _speciality;

        public string Speciality
        {
            get => _speciality;
            set => _speciality = value;
        }



        public WorkerEditingViewModel(Window w, Worker p) : base()
        {

            Thiswindow = w;

            WorkerId = p.WorkerId;
            Name = p.Name;
            Surname = p.Surname;
            Patronym = p.Patronym;
            Telephone = p.Telephone;
            Speciality = p.Speciality;

        }

    }
}
