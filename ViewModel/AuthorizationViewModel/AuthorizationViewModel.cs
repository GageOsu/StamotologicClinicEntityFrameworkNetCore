using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using StamotologicClinic.Models;
using StamotologicClinic.ViewModel.Command;
using StamotologicClinic.View.MainView;

namespace StamotologicClinic.ViewModel.AuthorizationViewModel
{
    internal class AuthorizationViewModel : INotifyPropertyChanged
    {
 

        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private void Enter(object parameter)
        {
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                var user = db.Accounts.FirstOrDefault(u => u.Login == Login && u.Password == Password);
                if (user != null)
                {
                    MainView mainView = new MainView();
                    mainView.Show();
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
        public ICommand LoginCommand { get; }

        public AuthorizationViewModel()
        {
            LoginCommand = new RelayCommand(Enter);
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}