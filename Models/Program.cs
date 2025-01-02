﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models;

public partial class Program
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string ProgramName { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Benefits { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Charge { get; set; }
}
