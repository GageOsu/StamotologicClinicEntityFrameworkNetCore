using StamotologicClinic.ViewModel.CRUDViewModel.CRUDCategoriesViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StamotologicClinic.Models;

public partial class TypeService
{
    public int Idservice { get; set; }

    public int? Idcategory { get; set; }

    public string? DescriptionService { get; set; }

    public decimal? Price { get; set; }

    public int? Count { get; set; }

    public virtual Category? IdcategoryNavigation { get; set; }

    public virtual ICollection<PriceHistory> PriceHistories { get; set; } = new List<PriceHistory>();

    public virtual ICollection<RecordHistory> RecordHistories { get; set; } = new List<RecordHistory>();

    [NotMapped]
    public Category CategoriesPosition
    {
        get
        {
            return ReadCategoriesViewModel.GetCategoriesById((int)Idcategory);
        }
    }
}
