using System;
using System.Collections.Generic;

namespace MVCProject.Models;

public partial class Program
{
    public string ProgramName { get; set; } = null!;

    public string? Benefits { get; set; }

    public decimal? Charge { get; set; }
}
