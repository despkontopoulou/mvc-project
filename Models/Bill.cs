using System;
using System.Collections.Generic;

namespace MVCProject.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public string? PhoneNumber { get; set; }

    public decimal? Costs { get; set; }

    public virtual Phone? PhoneNumberNavigation { get; set; }

    public virtual ICollection<Call> Calls { get; set; } = new List<Call>();
}
