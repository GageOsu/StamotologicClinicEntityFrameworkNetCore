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
using StamotologicClinic.View.CRUDView.CRUDMedicalPersonnelsView;
using System.Windows.Controls;

namespace StamotologicClinic.ViewModel.Main
{
    internal class MainViewModel : INotifyPropertyChanged
    {
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
        public MedicalPersonnel SelectetMedicalPersonnels { get; set; }

       public MainViewModel()
       {
            foreach (var item in ReadPositionViewModel.AllPosition())
            {
                _positions.Add(item);
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

        private void SetPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        private void _penCreateMedicalPersonnel()
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
                    _penCreateMedicalPersonnel();
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





        private RelayCommand _deleteItem;

        public RelayCommand DeleteItem
        {
            get
            {
                return _deleteItem ?? new RelayCommand(obj =>
                {
                    bool result = false;
                    if(SelectetTabItem.Name == "MedicalPersonalTab" && SelectetMedicalPersonnels != null)
                    {
                        result = DeleteMedicalPersonnelsViewModel.DeleteMedicalPersonnels(SelectetMedicalPersonnels);
                        UpdateAllMedicalPersonnelsView();
                    }

                }
                );
            }
        }


        private void UpdateAllMedicalPersonnelsView()
        {
            AllMedicalPersonnels = ReadMedicalPersonnelsViewModel.GetAllMedicalPersonnel();
            MainView.AllMedicalPersonnelsView.ItemsSource = null;
            MainView.AllMedicalPersonnelsView.Items.Clear();
            MainView.AllMedicalPersonnelsView.ItemsSource = AllMedicalPersonnels;
            MainView.AllMedicalPersonnelsView.Items.Refresh();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
