using StamotologicClinic.Models;
using StamotologicClinic.ViewModel.Command;
using StamotologicClinic.ViewModel.CRUDViewModel.CRUDPosition;
using StamotologicClinic.ViewModel.Main;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDMedicalPersonnelsViewModel
{
    internal class UpdateNewMedicalPersonnelsVewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _middlename;
        private Position _position;
        private ObservableCollection<Position> _positions = new ObservableCollection<Position>();
        public MedicalPersonnel MedicalSelectedItem { get; set; }
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

        public string Middlename
        {
            get
            {
                return _middlename;
            }
            set
            {
                _middlename = value;
                OnPropertyChanged(nameof(Middlename));
            }
        }
        public Position Position
        {
            get
            {
                return _position;
            }
            set 
            { 
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        public ObservableCollection<Position> Positions
        {
            get
            {
                return _positions;
            }
            set
            {
                _positions = value;
                OnPropertyChanged(nameof(Positions));
            }
        }

        public UpdateNewMedicalPersonnelsVewModel()
        {
            MedicalSelectedItem = MainViewModel.SelectetMedicalPersonnels;
            foreach (var item in ReadPositionViewModel.AllPosition())
            {
                _positions.Add(item);
            }
        }
        public bool UpdateMedicalPersonnels(MedicalPersonnel personnel,  Position newPosition)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                MedicalPersonnel medicalPersonnels = db.MedicalPersonnels.FirstOrDefault(p => p.IdmedicalPersonnel == personnel.IdmedicalPersonnel);
                {
                    medicalPersonnels.Surname = personnel.Surname;
                    medicalPersonnels.Name = personnel.Name;
                    medicalPersonnels.MiddleName = personnel.MiddleName;
                    medicalPersonnels.Idposition = personnel.Idposition;
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }


        private RelayCommand _updateMedicalPesonel;
        public RelayCommand UpdateMedicalPesonel
        {
            get
            {
                return _updateMedicalPesonel ?? new RelayCommand(obj =>
                {
                    UpdateMedicalPersonnels(MedicalSelectedItem, Position);
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
