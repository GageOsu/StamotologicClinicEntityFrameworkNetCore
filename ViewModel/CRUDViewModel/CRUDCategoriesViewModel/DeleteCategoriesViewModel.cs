using StamotologicClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDCategoriesViewModel
{
    class DeleteCategoriesViewModel
    {
        public static bool DeleteCategories(Category categories)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                db.Categories.Remove(categories);
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
