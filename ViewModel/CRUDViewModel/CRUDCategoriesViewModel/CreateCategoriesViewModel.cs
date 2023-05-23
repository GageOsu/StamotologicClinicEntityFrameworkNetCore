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

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDCategoriesViewModel
{
    internal class CreateCategoriesViewModel : INotifyPropertyChanged
    {
        private string _category;
        public string Category 
        { 
            get 
            { 
                return _category; 
            } 
            set 
            { 
                _category = value;
                OnPropertyChanged(nameof(Category));
                
            } 
        }

        public bool CreateCategories(string category)
        {
            bool result = false;
            using(StomatologicClinicContext db = new StomatologicClinicContext())
            {
                bool checkIsExist = db.Categories.Any(p => p.Category1 == category);
                if (!checkIsExist)
                {
                    Category CreateCategories = new Category
                    {
                        Category1 = category,
                    };
                    db.Categories.Add(CreateCategories);
                    db.SaveChanges();
                    result = true;
                }
                return result;
            }
        }

        private RelayCommand _addCatigories;
        public RelayCommand AddCatigories
        {
            get
            {
                return _addCatigories ?? new RelayCommand(obj =>
                {
                    bool result = false;
                    if(Category == null)
                    {
                        MessageBox.Show("Ошибка");
                    }
                    else
                    {
                        result = CreateCategories(Category);
                        MainViewModel.UpdateAllCategoriesView();
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
