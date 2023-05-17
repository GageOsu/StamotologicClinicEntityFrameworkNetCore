using StamotologicClinic.Models;
using StamotologicClinic.ViewModel.Command;
using StamotologicClinic.ViewModel.CRUDViewModel.CRUDPosition;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDMedicalPersonnelsViewModel
{
    internal class UpdateNewMedicalPersonnelsVewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _middlename;
        private Position _position;
        private ObservableCollection<Position> _positions = new ObservableCollection<Position>();
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
            foreach (var item in ReadPositionViewModel.AllPosition())
            {
                _positions.Add(item);
            }

        }

        public bool UpdateMedicalPersonnels(MedicalPersonnel OldMedicalPersonal, string NewName, string NewSurname, string MewMiddleName, Position newPosition)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                MedicalPersonnel medicalPersonnels = db.MedicalPersonnels.FirstOrDefault(p => p.IdmedicalPersonnel == OldMedicalPersonal.IdmedicalPersonnel);
                {
                    medicalPersonnels.Surname = NewSurname;
                    medicalPersonnels.Name = NewName;
                    medicalPersonnels.MiddleName = MewMiddleName;
                    medicalPersonnels.Idposition = newPosition.Idposition;
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }








        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
