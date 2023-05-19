using System;
using System.Collections.Generic;

namespace CRUD_cakes.Models;

public partial class Cake
{
    public int CakeId { get; set; }

    public string CakeName { get; set; } = null!;

    public string BrandName { get; set; } = null!;

    public int Weight { get; set; }

    public int Price { get; set; }

    public int Calories { get; set; }

    public bool Gluten { get; set; }
}
