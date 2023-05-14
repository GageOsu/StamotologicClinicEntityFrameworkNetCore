using System;
using System.Collections.Generic;

namespace StamotologicClinic.Models;

public partial class RecordHistory
{
    public int Idrecord { get; set; }

    public int? IdmedicalPersonal { get; set; }

    public int? Idpatient { get; set; }

    public int? Idservice { get; set; }

    public DateTime? DateRegistration { get; set; }

    public DateTime? DateСompletion { get; set; }

    public bool? Status { get; set; }

    public virtual MedicalPersonnel? IdmedicalPersonalNavigation { get; set; }

    public virtual Patient? IdpatientNavigation { get; set; }

    public virtual TypeService? IdserviceNavigation { get; set; }
}
