using System;
using System.Collections.Generic;

namespace StamotologicClinic.Models;

public partial class Position
{
    public int Idposition { get; set; }

    public string? Position1 { get; set; }

    public virtual ICollection<MedicalPersonnel> MedicalPersonnel { get; set; } = new List<MedicalPersonnel>();
}
