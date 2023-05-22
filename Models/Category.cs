using StamotologicClinic.ViewModel.CRUDViewModel.CRUDCategoriesViewModel;
using StamotologicClinic.ViewModel.CRUDViewModel.CRUDMedicalPersonnelsViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StamotologicClinic.Models;

public partial class Category
{
    public int Idcategory { get; set; }

    public string? Category1 { get; set; }

    public virtual ICollection<TypeService> TypeServices { get; set; } = new List<TypeService>();


}
