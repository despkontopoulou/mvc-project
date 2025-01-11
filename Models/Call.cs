using System;
using System.Collections.Generic;

namespace MVCProject.Models;

public partial class Call
{
    public int CallId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
