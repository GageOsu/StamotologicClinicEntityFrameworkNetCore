using StamotologicClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDRecordHistory
{
    class ReadRecordHistoryViewModel
    {
        public static List<RecordHistory> GetAllRecordHistory()
        {
            using (StomatologicClinicContext db =  new StomatologicClinicContext())
            {
                var result = db.RecordHistories.ToList();
                return result;
            }
        }

        public static MedicalPersonnel GetMedicalById(int id)
        {
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                MedicalPersonnel pos = db.MedicalPersonnels.FirstOrDefault(p => p.IdmedicalPersonnel == id);
                return pos;
            }
        }

        public static TypeService GetTypeServiceById(int id)
        {
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                TypeService pos = db.TypeServices.FirstOrDefault(p => p.Idservice == id);
                return pos;
            }
        }
        public static Patient GetPateintById(int id)
        {
            using(StomatologicClinicContext db = new StomatologicClinicContext())
            {
                Patient pos = db.Patients.FirstOrDefault(p => p.Idpatient == id);
                return pos;
            }
        }
    }
}
