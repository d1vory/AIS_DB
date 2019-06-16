using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.Clients
{
    class ClientEditingViewModel:CrudVMBase
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


            Client c = db.Clients.SingleOrDefault(g => g.ClientId == ClientId);
            if (c != null)
            {

                c.ClientId = ClientId;
                c.Surname = Surname;
                c.Name = Name;
                c.Patronym = Patronym;
                c.Telephone = Telephone;
                c.District = District;
                c.Region = Region;
                c.City = City;
                c.Street = Street;
                c.FlatNumber = FlatNumber;
                c.ApartmentNumber = ApartmentNumber;

                db.SaveChanges();

            }


            Thiswindow.Close();
        }
 

        private Window _thiswindow;

        public Window Thiswindow
        {
            get => _thiswindow;
            set => _thiswindow = value;
        }

        private int _clientId;

        public int ClientId
        {
            get => _clientId;
            set => _clientId = value;
        }

        private string _surname;

        public string Surname
        {
            get => _surname;
            set => _surname = value;
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

        private string _telephone;

        public string Telephone
        {
            get => _telephone;
            set => _telephone = value;
        }

        private string _district;

        public string District
        {
            get => _district;
            set => _district = value;
        }

        private string _region;

        public string Region
        {
            get => _region;
            set => _region = value;
        }

        private string _city;

        public string City
        {
            get => _city;
            set => _city = value;
        }

        private string _street;

        public string Street
        {
            get => _street;
            set => _street = value;
        }

        private string _flatNumber;

        public string FlatNumber
        {
            get => _flatNumber;
            set => _flatNumber = value;
        }

        private string _apartmentNumber;

        public string ApartmentNumber
        {
            get => _apartmentNumber;
            set => _apartmentNumber = value;
        }


        public ClientEditingViewModel(Window w, Client c) : base()
        {

            Thiswindow = w;

            ClientId = c.ClientId;
            Name = c.Name;
            Surname = c.Surname;
            Patronym = c.Patronym;
            Telephone = c.Telephone;
            District = c.District;
            Region = c.Region;
            City = c.City;
            Street = c.Street;
            FlatNumber = c.FlatNumber;
            ApartmentNumber = c.ApartmentNumber;

           
        }

    }
}
