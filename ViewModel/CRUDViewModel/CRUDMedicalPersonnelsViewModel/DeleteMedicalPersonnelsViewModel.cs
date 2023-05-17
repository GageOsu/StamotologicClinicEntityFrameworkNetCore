using StamotologicClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDMedicalPersonnelsViewModel
{
    internal class DeleteMedicalPersonnelsViewModel
    {
        public static bool DeleteMedicalPersonnels(MedicalPersonnel medicalPersonnel)
        {
            bool result = false;
            using (StomatologicClinicContext db =  new StomatologicClinicContext())
            {
                db.MedicalPersonnels.Remove(medicalPersonnel);
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}