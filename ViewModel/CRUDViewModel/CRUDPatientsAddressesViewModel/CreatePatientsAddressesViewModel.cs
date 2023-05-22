using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StamotologicClinic.Models;
using StamotologicClinic.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDPatientsAddressesViewModel
{
    internal class CreatePatientsAddressesViewModel : INotifyPropertyChanged
    {
        private string _surname;
        private string _name;
        private string _middleName;
        private string _sex;
        private string _insuranceCompany;
        private string _mhiPolice;
        private string _phoneNumber;
        private string _subject;
        private string _district;
        private string _city;
        private string _locality;
        private string _street;
        private string _house;

        public string Surname
        {
            get 
            { 
                return _surname; 
            } 
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string MiddleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        public string Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
                OnPropertyChanged(nameof(Sex));
            }
        }

        public string InsuranceCompany
        {
            get
            {
                return _insuranceCompany;
            }
            set
            {
                _insuranceCompany = value;
                OnPropertyChanged(nameof(InsuranceCompany));
            }
        }

        public string MHIPolice
        {
            get
            {
                return _mhiPolice;
            }
            set 
            {
                _mhiPolice = value;
                OnPropertyChanged(nameof(MHIPolice));
            }
        }

        public string PhoneNumber
        {
            get 
            { 
                return _phoneNumber; 
            }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string Subject
        {
            get
            { return _subject; }
            set
            {
                _subject = value;
                OnPropertyChanged(nameof(Subject));
            }
        }

        public string District
        {
            get { return _district; }
            set 
            { 
                _district = value;
                OnPropertyChanged(nameof(District));
            }
        }
        
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string Locality
        {
            get
            {
                return _locality;
            }
            set
            {
                _locality = value;
                OnPropertyChanged(nameof(Locality));
            }
        }

        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        public string House
        {
            get
            {
                return _house;
            }
            set 
            { 
                _house = value;
                OnPropertyChanged(nameof(House));
            }
        }

        public bool CreatePatientsAdresses(string surname, string name, string middlename, string sex, string insurancecompany, string mhipolice, string phonenumber, 
                                           string subject, string district, string city, string locality, string street, string house)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                bool checkIsExist = db.Patients.Any(p => p.Surname == surname && p.Name == name && p.MiddleName == middlename);
                if (!checkIsExist) 
                {
                    Address newAddresse = new Address();
                    {
                        Subject = subject;
                        District = district;
                        City = city;
                        Locality = locality;
                        Street = street;
                        House = house;
                    };
                    db.Addresses.Add(newAddresse);
                    db.SaveChanges();
                    Patient newPatient = new Patient()
                    {

                        Surname = surname,
                        Name = name,
                        MiddleName = middlename,
                        Sex = sex,
                        InsuranceCompany = insurancecompany,
                        Mhipolicy = mhipolice,
                        PhoneNumber = phonenumber,
                        Idadress = newAddresse.Idadress
                    };
                    db.Patients.Add(newPatient);
                    db.SaveChanges();
                }
                return result;
    }
        }



        private RelayCommand _newPatientsAdresses;
        public RelayCommand NewPatientsAdresses
        {
            get
            {
                return _newPatientsAdresses ?? new RelayCommand(obj =>
                {
                    bool result = false;
                    if(Name == null || Name.Replace(" ", "").Length == 0)
                    {
                        MessageBox.Show("Ошибка");
                    }
                    else
                    {
                        result = CreatePatientsAdresses(Surname, Name, MiddleName, Sex, InsuranceCompany, MHIPolice, PhoneNumber, Subject, District, City, Locality, Street, House);
                    }
                }
                );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
