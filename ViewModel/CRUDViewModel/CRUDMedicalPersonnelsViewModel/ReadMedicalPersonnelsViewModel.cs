using StamotologicClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDMedicalPersonnelsViewModel
{
    internal class ReadMedicalPersonnelsViewModel
    {
        public static List<MedicalPersonnel> GetAllMedicalPersonnel()
        {
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                var result = db.MedicalPersonnels.ToList();
                return result;
            }
        }

        public static Position GetPositionById(int id)
        {
            using(StomatologicClinicContext db = new StomatologicClinicContext())
            {
                Position pos = db.Positions.FirstOrDefault(p => p.Idposition == id);
                return pos;
            }
        }
    }
}
