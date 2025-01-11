using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models;

public partial class Bill
{
    [Key]
    public int BillId { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "decimal(7, 2)")]
    public decimal? Costs { get; set; }

    [ForeignKey("PhoneNumber")]
    [InverseProperty("Bills")]
    public virtual Phone? PhoneNumberNavigation { get; set; }


    [ForeignKey("BillId")]
    [InverseProperty("Bills")]
    public virtual ICollection<Call> Calls { get; set; } = new List<Call>();
}
