using System;
using System.Collections.Generic;

namespace StamotologicClinic.Models;

public partial class PriceHistory
{
    public int Idchanges { get; set; }

    public int? Idservice { get; set; }

    public decimal? NewPrices { get; set; }

    public decimal? OldPrices { get; set; }

    public DateTime? DateChange { get; set; }

    public virtual TypeService? IdserviceNavigation { get; set; }
}
