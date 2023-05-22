using StamotologicClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDTypeServicesViewModel
{
    class ReadTypeServicesViewModel
    {
        public static List<TypeService> GetAllTypeService()
        {
            StomatologicClinicContext db = new StomatologicClinicContext();
            var result = db.TypeServices.ToList();
            return result;
        }
    }
}
