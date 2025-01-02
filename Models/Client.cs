using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models;

public partial class Client
{
    [Key]
    public int ClientId { get; set; }

    [Column("AFM")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Afm { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    public int? UserId { get; set; }

    [ForeignKey("PhoneNumber")]
    [InverseProperty("Clients")]
    public virtual Phone? PhoneNumberNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Clients")]
    public virtual User? User { get; set; }
}
