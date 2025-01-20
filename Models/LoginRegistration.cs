using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank_Web_Project.Models;

[Table("LoginRegistration")]
public partial class LoginRegistration
{
    [Key]
    [Column("RegistrationID")]
    public int RegistrationId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LoginTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LogoutTime { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    public bool IsSuccess { get; set; }

    [Column("IPAddress")]
    [StringLength(50)]
    public string? Ipaddress { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("LoginRegistrations")]
    public virtual User User { get; set; } = null!;
}
