using System;
using System.Collections.Generic;

namespace StamotologicClinic.Models;

public partial class Patient
{
    public int Idpatient { get; set; }

    public int? Idadress { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public string? Sex { get; set; }

    public string? InsuranceCompany { get; set; }

    public string? Mhipolicy { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual Address? IdadressNavigation { get; set; }

    public virtual ICollection<RecordHistory> RecordHistories { get; set; } = new List<RecordHistory>();
}
