using StamotologicClinic.ViewModel.CRUDViewModel.CRUDMedicalPersonnelsViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StamotologicClinic.Models;

public partial class MedicalPersonnel
{
    public int IdmedicalPersonnel { get; set; }

    public int? Idposition { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Position? IdpositionNavigation { get; set; }

    public virtual ICollection<RecordHistory> RecordHistories { get; set; } = new List<RecordHistory>();

    [NotMapped]
    public Position MedicalPersonnelsPosition
    {
        get
        {
            return ReadMedicalPersonnelsViewModel.GetPositionById((int)Idposition);
        }
    }
}
