using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank_Web_Project.Models;

[Table("User")]
public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [Column("PersonID")]
    public int PersonId { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(255)]
    public string Password { get; set; } = null!;

    public byte Permissions { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<LoginRegistration> LoginRegistrations { get; set; } = new List<LoginRegistration>();

    [InverseProperty("SenderUser")]
    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    [ForeignKey("PersonId")]
    [InverseProperty("Users")]
    public virtual Person Person { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
