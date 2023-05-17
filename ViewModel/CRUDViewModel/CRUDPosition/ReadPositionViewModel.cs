using StamotologicClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamotologicClinic.ViewModel.CRUDViewModel.CRUDPosition
{
    internal class ReadPositionViewModel
    {
        public static List<Position> AllPosition()
        {
            StomatologicClinicContext db = new StomatologicClinicContext();
            var result = db.Positions.ToList();
            return result;
        }
    }
}
