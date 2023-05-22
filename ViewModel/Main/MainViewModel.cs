using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StamotologicClinic.Models;
using StamotologicClinic.View.CRUDView.CRUDMedicalPersonnelsView;
using StamotologicClinic.View.MainView;
using StamotologicClinic.ViewModel.Command;
using StamotologicClinic.ViewModel.CRUDViewModel.CRUDMedicalPersonnelsViewModel;
using StamotologicClinic.ViewModel.CRUDViewModel.CRUDPosition;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using StamotologicClinic.View.CRUDView.CRUDPositionsView;
using StamotologicClinic.ViewModel.CRUDViewModel.CRUDPatientsAddressesViewModel;
using StamotologicClinic.View.CRUDView.CRUDPatientsAddressesView;

namespace StamotologicClinic.ViewModel.Main
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        #region Выбор для редактирования
        private static MedicalPersonnel _selectedMedicalPersonnels;
        public static MedicalPersonnel SelectedMedicalPersonnels
        {
            get { return _selectedMedicalPersonnels; }
            set
            {
                _selectedMedicalPersonnels = value;
            }
        }

        private static Position _selectedPosition;
        public static Position SelectedPosition
        {
            get
            {
                return _selectedPosition;
            }
            set
            {
                _selectedPosition = value;
            }
        }
        #endregion

        private ObservableCollection<Position> _positions = new ObservableCollection<Position>();
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

        public TabItem SelectetTabItem { get; set; }

       public MainViewModel()
       {
            foreach (var item in ReadPositionViewModel.GetPosition())
            {
                _positions.Add(item);
            }
       }

        #region Вывод Таблиц
        private List<Patient> _allPatients = ReadPatientsAdressesViewModel.GetAllPatient();
        public List<Patient> AllPatients
        {
            get
            {
                return _allPatients;
            }
            set 
            { 
                _allPatients = value;
                OnPropertyChanged(nameof(AllPatients));
            }
        }

        private List<Position> _allPosition = ReadPositionViewModel.GetPosition();
        public List<Position> AllPosition
        {
            get
            {
                return _allPosition;
            }
            set
            {
                _allPosition = value;
                OnPropertyChanged(nameof(AllPosition));
            }
        }
       
        private List<MedicalPersonnel> _allMedicalPersonnels = ReadMedicalPersonnelsViewModel.GetAllMedicalPersonnel();

        public List<MedicalPersonnel> AllMedicalPersonnels
        {
            get { return _allMedicalPersonnels; }
            set
            {
                _allMedicalPersonnels = value;
                OnPropertyChanged(nameof(AllMedicalPersonnels));
            }
        }
        #endregion

        #region Открытия окон
        private void SetPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        #region Открытия CRUD MedicalPersonnels
        private void _openCreateMedicalPersonnel()
        {
            AddNewMedicalPersonnelsView addNewMedicalPersonnelView = new AddNewMedicalPersonnelsView();
            SetPositionAndOpen(addNewMedicalPersonnelView);
        }

        private RelayCommand openCreateNewMedicalPersonnel;
        public RelayCommand OpenCreateNewMedicalPersonnel
        {
            get
            {
                return openCreateNewMedicalPersonnel ?? new RelayCommand(obj =>
                {
                    _openCreateMedicalPersonnel();
                }
                );
            }
        }

        private void _openUpdateMedicalPersonnels()
        {
            UpdateMedicalPersonnelsView updateMedicalPersonnelsView = new UpdateMedicalPersonnelsView();
            SetPositionAndOpen(updateMedicalPersonnelsView);
        }

        private RelayCommand openUpdateMedicalPersonnel;
        public RelayCommand OpenUpdateMedicalPersonnel
        {
            get
            {
                return openUpdateMedicalPersonnel ?? new RelayCommand(obj =>
                {
                    _openUpdateMedicalPersonnels();
                }
                );
            }
        }
        #endregion

        #region Открытия CRUD Positions
        private void _openCreatePosition()
        {
            CreateNewPositionsView createNewPositionsView = new CreateNewPositionsView();
            SetPositionAndOpen(createNewPositionsView);
        }
        private RelayCommand openCreatePosition;
        public RelayCommand OpenCreatePosition
        {
            get
            {
                return openCreatePosition ?? new RelayCommand(obj =>
                {
                    _openCreatePosition();
                }
                );
            }
        }

        private void _openUpdatePosition()
        {
            UpdatePositionsView updatePositionsView = new UpdatePositionsView();
            SetPositionAndOpen(updatePositionsView);
        }
        private RelayCommand openUpdatePosition;
        public RelayCommand OpenUpdatePosition
        {
            get
            {
                return openUpdatePosition ?? new RelayCommand(obj =>
                {
                    _openUpdatePosition();
                }
                );
            }
        }
        #endregion

        #region Открытия CRUD Patients Adresses
        private void _openCreatePatientsAdresses()
        {
            CreatePatientsAddressesView createPatientsAddressesView = new CreatePatientsAddressesView();
            SetPositionAndOpen(createPatientsAddressesView);
        }
        private RelayCommand openCreatePatientsAddresses;
        public RelayCommand OpenCreatePatientsAddresses
        {
            get
            {
                return openCreatePatientsAddresses ?? new RelayCommand(obj =>
                {
                    _openCreatePatientsAdresses();
                }
                );
            }
        }
        #endregion
        #endregion

        #region Редактирования данных
        private RelayCommand _updateItem;
        public RelayCommand UpdateItem
        {
            get
            {
                return _updateItem ?? new RelayCommand(obj =>
                {
                    if(SelectetTabItem.Name == "MedicalPersonalTab" && SelectedMedicalPersonnels != null)
                    {
                        _openUpdateMedicalPersonnels();
                    }
                    if(SelectetTabItem.Name == "PositionTab" && SelectedPosition != null)
                    {
                        _openUpdatePosition();
                    }
                }
                );
            }
        }
        #endregion

        #region Удаления данных
        private RelayCommand _deleteItem;

        public RelayCommand DeleteItem
        {
            get
            {
                return _deleteItem ?? new RelayCommand(obj =>
                {
                    bool result = false;
                    if(SelectetTabItem.Name == "MedicalPersonalTab" && SelectedMedicalPersonnels != null)
                    {
                        result = DeleteMedicalPersonnelsViewModel.DeleteMedicalPersonnels(SelectedMedicalPersonnels);
                        UpdateAllMedicalPersonnelsView();
                    }
                    if(SelectetTabItem.Name == "PositionTab" && SelectedPosition != null)
                    {
                        result = DeletePositionViewModel.DeletePosition(SelectedPosition);
                        UpdateAllPositionsView();
                    }

                }
                );
            }
        }
        #endregion


        #region Обноввления для вывода таблиц 
        public static void UpdateAllMedicalPersonnelsView()
        {
            MainView.AllMedicalPersonnelsView.ItemsSource = null;
            MainView.AllMedicalPersonnelsView.Items.Clear();
            MainView.AllMedicalPersonnelsView.ItemsSource = ReadMedicalPersonnelsViewModel.GetAllMedicalPersonnel();
            MainView.AllMedicalPersonnelsView.Items.Refresh();
        }

        public static void UpdateAllPositionsView()
        {
            MainView.AllPositionsView.ItemsSource = null;
            MainView.AllPositionsView.Items.Clear();
            MainView.AllPositionsView.ItemsSource = ReadPositionViewModel.GetPosition();
            MainView.AllPositionsView.Items.Refresh();
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
