using StamotologicClinic.Models;
using StamotologicClinic.ViewModel.Command;
using StamotologicClinic.ViewModel.Main;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDPosition
{
    internal class UpdatePositionViewModel
    {
        private Position _position;
        private ObservableCollection<Position> _positions = new ObservableCollection<Position>();
        public Position PositionSelected { get; set; }
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

            public UpdatePositionViewModel()
            {
                PositionSelected = MainViewModel.SelectedPosition;
            }

        public bool UpdatePosition(Position position)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                MedicalPersonnel Position = db.MedicalPersonnels.FirstOrDefault(p => p.Idposition == position.Idposition);
                {
                    position.Position1 = position.Position1;
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }


        private RelayCommand _updatePositions;
        public RelayCommand UpdatePositions
        {
            get
            {
                return _updatePositions ?? new RelayCommand(obj =>
                {
                    UpdatePosition(PositionSelected);
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
