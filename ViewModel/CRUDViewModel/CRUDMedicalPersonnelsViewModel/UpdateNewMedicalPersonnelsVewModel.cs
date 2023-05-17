using StamotologicClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDMedicalPersonnelsViewModel
{
    internal class UpdateNewMedicalPersonnelsVewModel
    { 
        public bool EditMedicalPersonnel(MedicalPersonnel OldMedicalPersonal, string NewName, string NewSurname, string MewMiddleName, Position newPosition)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                MedicalPersonnel medicalPersonnels = db.MedicalPersonnels.FirstOrDefault(p => p.IdmedicalPersonnel == OldMedicalPersonal.IdmedicalPersonnel);
                {
                    medicalPersonnels.Surname = NewSurname;
                    medicalPersonnels.Name = NewName;
                    medicalPersonnels.MiddleName = MewMiddleName;
                    medicalPersonnels.Idposition = newPosition.Idposition;
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
    }
}
