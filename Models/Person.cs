using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank_Web_Project.Models;

[Table("Person")]
public partial class Person
{
    [Key]
    [Column("PersonID")]
    public int PersonId { get; set; }

    [StringLength(50)]
    public string NationalNo { get; set; } = null!;

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string? SecondName { get; set; }

    [StringLength(50)]
    public string? ThirdName { get; set; }

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DateOfBirth { get; set; }

    public byte Gender { get; set; }

    [StringLength(255)]
    public string? Address { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }

    [StringLength(255)]
    public string? ImagePath { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("People")]
    public virtual Country Country { get; set; } = null!;

    [InverseProperty("ReceiverPerson")]
    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    [InverseProperty("Client")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [InverseProperty("Person")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
