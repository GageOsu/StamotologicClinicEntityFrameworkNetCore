using StamotologicClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDCategoriesViewModel
{
    internal class ReadCategoriesViewModel
    {
        public static List<Category> GetCategories()
        {
            StomatologicClinicContext db = new StomatologicClinicContext();
            var result = db.Categories.ToList();
            return result;
        }
        public static Category GetCategoriesById(int id)
        {
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                Category pos = db.Categories.FirstOrDefault(p => p.Idcategory == id);
                return pos;
            }
        }
    }
}
