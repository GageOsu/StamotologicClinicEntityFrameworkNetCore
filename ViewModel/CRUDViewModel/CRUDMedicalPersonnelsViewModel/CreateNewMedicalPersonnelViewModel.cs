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
    internal class CreateNewMedicalPersonnelViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Position> _colPosition;
        public ObservableCollection<Position> ColPosition
        {
            get
            {
                return _colPosition;
            }
            set
            {
                _colPosition = value;
                OnPropertyChanged(nameof(ColPosition));
            }
        }

        private string _surname;
        private string _name;
        private string _middlename;
        private Position _position;

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
        private ObservableCollection<Position> _positions = new ObservableCollection<Position>();

        public CreateNewMedicalPersonnelViewModel()
        {
            foreach (var item in ReadPositionViewModel.AllPosition())
            {
                _positions.Add(item);
            }

        }



        public bool CreateMedicalPersonnel(string surname, string name, string middleName, Position positions)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                bool checkIsExist = db.MedicalPersonnels.Any(p => p.Surname == surname && p.Name == name && p.MiddleName == middleName && p.Idposition == positions.Idposition);
                if (!checkIsExist)
                {

                    MedicalPersonnel newMedicalPersonal = new MedicalPersonnel
                    {
                        Surname = surname,
                        Name = name,
                        MiddleName = middleName,
                        Idposition = positions.Idposition,
                    };
                    db.MedicalPersonnels.Add(newMedicalPersonal);
                    db.SaveChanges();
                    result = true;

                }
            }
            return result;
        }

        private RelayCommand addNewMedicalPesonel;
        public RelayCommand AddNewMedicalPesonel
        {
            get
            {
                return addNewMedicalPesonel ?? new RelayCommand(obj =>
                {
                    bool result = true;
                    if (Name == null || Name.Replace(" ","").Length == 0)
                    {
                        MessageBox.Show("Ошибка");
                    }
                    else
                    {
                        result = CreateMedicalPersonnel(Surname, Name, Middlename, Position);
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
