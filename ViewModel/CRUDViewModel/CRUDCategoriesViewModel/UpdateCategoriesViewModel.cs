using StamotologicClinic.Models;
using StamotologicClinic.ViewModel.Command;
using StamotologicClinic.ViewModel.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDCategoriesViewModel
{
    class UpdateCategoriesViewModel : INotifyPropertyChanged
    {
        public Category CategoriesSelected { get; set; }
        private Category _categories;
        public Category Categories
        {
            get 
            {
                return _categories; 
            }
            set 
            { 
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        public UpdateCategoriesViewModel()
        {
            CategoriesSelected = MainViewModel.SelectedCategories;
        }

        public bool UpdateCategories(Category categories)
        {
            bool result = false;
            using(StomatologicClinicContext db =  new StomatologicClinicContext())
            {
                Category newcategories = db.Categories.FirstOrDefault(P => P.Idcategory == categories.Idcategory);
                {
                    newcategories.Category1 = categories.Category1;
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        private RelayCommand _updateCategories;
        public RelayCommand UpdateCategorie
        {
            get
            {
                return _updateCategories ?? new RelayCommand(obj =>
                {
                    UpdateCategories(CategoriesSelected);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
