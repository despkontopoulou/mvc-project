using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models;

public partial class Call
{
    [Key]
    public int CallId { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [ForeignKey("CallId")]
    [InverseProperty("Calls")]
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
