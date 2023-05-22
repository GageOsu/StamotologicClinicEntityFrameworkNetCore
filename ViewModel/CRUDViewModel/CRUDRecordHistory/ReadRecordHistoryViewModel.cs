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
    }
}
