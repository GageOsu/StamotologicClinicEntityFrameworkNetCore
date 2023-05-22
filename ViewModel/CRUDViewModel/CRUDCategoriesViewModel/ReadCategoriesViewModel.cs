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
    }
}
