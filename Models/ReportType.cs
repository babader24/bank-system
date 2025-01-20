using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank_Web_Project.Models;

public partial class ReportType
{
    [Key]
    [Column("ReportID")]
    public int ReportId { get; set; }

    [StringLength(100)]
    public string ReportName { get; set; } = null!;
}
