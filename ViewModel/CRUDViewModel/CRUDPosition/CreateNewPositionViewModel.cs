using StamotologicClinic.Models;
using StamotologicClinic.ViewModel.Command;
using StamotologicClinic.ViewModel.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDPosition
{
    internal class CreateNewPositionViewModel : INotifyPropertyChanged
    {
        private string _position;
        public string Position
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

        public bool CreatePosition(string nameposition)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                bool checkIsExist = db.Positions.Any(p => p.Position1 == nameposition);
                if (!checkIsExist)
                {
                    Position AddPosition = new Position
                    {
                        Position1 = nameposition,
                    };
                    db.Positions.Add(AddPosition);
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        private RelayCommand _createNewPosition;
        public RelayCommand CreateNewPosition
        {
            get
            {
                return _createNewPosition ?? new RelayCommand(obj =>
                {
                    CreatePosition(Position);
                    MainViewModel.UpdateAllPositionsView();
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
