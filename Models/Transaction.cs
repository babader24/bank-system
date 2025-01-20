using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank_Web_Project.Models;

public partial class Transaction
{
    [Key]
    [Column("TransactionID")]
    public int TransactionId { get; set; }

    [Column("ClientID")]
    public int ClientId { get; set; }

    public byte TransactionType { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal Amount { get; set; }

    [Column("CurrencyID")]
    public int CurrencyId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    public bool Status { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    [Column("TargetClientID")]
    public int? TargetClientId { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("Transactions")]
    public virtual Person Client { get; set; } = null!;

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("Transactions")]
    public virtual User CreatedByUser { get; set; } = null!;

    [ForeignKey("CurrencyId")]
    [InverseProperty("Transactions")]
    public virtual Currency Currency { get; set; } = null!;
}
