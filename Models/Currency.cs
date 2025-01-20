using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank_Web_Project.Models;

[Table("Currency")]
public partial class Currency
{
    [Key]
    [Column("CurrencyID")]
    public int CurrencyId { get; set; }

    [StringLength(100)]
    public string CountryName { get; set; } = null!;

    [StringLength(10)]
    public string CurrencyCode { get; set; } = null!;

    [Column(TypeName = "decimal(18, 4)")]
    public decimal ExchangeRateToLocal { get; set; }

    [InverseProperty("Currency")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
