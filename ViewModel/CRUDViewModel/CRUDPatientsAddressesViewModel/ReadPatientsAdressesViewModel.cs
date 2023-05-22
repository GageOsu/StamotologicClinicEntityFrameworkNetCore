using StamotologicClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDPatientsAddressesViewModel
{
    internal class ReadPatientsAdressesViewModel
    {
        public static List <Patient> GetAllPatient()
        {
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                var result = db.Patients.ToList();
                return result;
            }
        }
    }
}
