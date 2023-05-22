using StamotologicClinic.ViewModel.CRUDViewModel.CRUDMedicalPersonnelsViewModel;
using StamotologicClinic.ViewModel.CRUDViewModel.CRUDRecordHistory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace StamotologicClinic.Models;

public partial class RecordHistory
{
    public int Idrecord { get; set; }

    public int? IdmedicalPersonal { get; set; }

    public int? Idpatient { get; set; }

    public int? Idservice { get; set; }

    public DateTime? DateRegistration { get; set; }

    public DateTime? DateСompletion { get; set; }

    public string? Status { get; set; }
    
    public int? Count { get; set; }

    public virtual MedicalPersonnel? IdmedicalPersonalNavigation { get; set; }

    public virtual Patient? IdpatientNavigation { get; set; }

    public virtual TypeService? IdserviceNavigation { get; set; }

    [NotMapped]
    public MedicalPersonnel MedicalPersonnelsPosition
    {
        get
        {
            return ReadRecordHistoryViewModel.GetMedicalById((int)IdmedicalPersonal);
        }
    }
    [NotMapped]
    public TypeService TypeServiceId
    {
        get
        {
            return ReadRecordHistoryViewModel.GetTypeServiceById((int)Idservice);
        }
    }
    [NotMapped]
    public Patient PatientId
    {
        get
        {
            return ReadRecordHistoryViewModel.GetPateintById((int)Idpatient);
        }
    }

}
