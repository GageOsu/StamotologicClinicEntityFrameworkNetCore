using System;
using System.Collections.Generic;

namespace StamotologicClinic.Models;

public partial class Address
{
    public int Idadress { get; set; }

    public string? Subject { get; set; }

    public string? District { get; set; }

    public string? City { get; set; }

    public string? Locality { get; set; }

    public string? Street { get; set; }

    public string? House { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
