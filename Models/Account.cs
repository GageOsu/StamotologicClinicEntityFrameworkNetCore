using System;
using System.Collections.Generic;

namespace StamotologicClinic.Models;

public partial class Account
{
    public int Idaccount { get; set; }

    public int? IdmedicalPersonnel { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual MedicalPersonnel? IdmedicalPersonnelNavigation { get; set; }
}
