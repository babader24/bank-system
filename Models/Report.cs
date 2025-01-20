using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank_Web_Project.Models;

public partial class Report
{
    [Key]
    [Column("ReportID")]
    public int ReportId { get; set; }

    public byte ReportType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    public string ReportData { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime GeneratedAt { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    public byte ReportStatus { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Reports")]
    public virtual User User { get; set; } = null!;
}
