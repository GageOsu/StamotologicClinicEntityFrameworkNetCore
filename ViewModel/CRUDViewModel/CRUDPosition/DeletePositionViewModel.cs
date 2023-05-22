using StamotologicClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDPosition
{
    internal class DeletePositionViewModel
    {
        public static bool DeletePosition(Position position)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
