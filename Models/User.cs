using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MVCProject.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Display(Name = "Username")]
    public string? Username { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Display(Name = "User Property - Role")]
    public string? Property { get; set; }

    [Display(Name = "Password")]
    [MinLength(8)]
    [MaxLength(15)]
    public string PasswordHash { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    [InverseProperty("User")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
     
    [InverseProperty("User")]
    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
