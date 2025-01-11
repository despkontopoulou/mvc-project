using System;
using System.Collections.Generic;

namespace MVCProject.Models;

public partial class Seller
{
    public int SellerId { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
