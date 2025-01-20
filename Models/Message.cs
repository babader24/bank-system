using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank_Web_Project.Models;

public partial class Message
{
    [Key]
    [Column("MessageID")]
    public int MessageId { get; set; }

    [Column("SenderUserID")]
    public int SenderUserId { get; set; }

    [Column("ReceiverPersonID")]
    public int ReceiverPersonId { get; set; }

    public string MessageContent { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? MessageDate { get; set; }

    public bool? IsRead { get; set; }

    [ForeignKey("ReceiverPersonId")]
    [InverseProperty("Messages")]
    public virtual Person ReceiverPerson { get; set; } = null!;

    [ForeignKey("SenderUserId")]
    [InverseProperty("Messages")]
    public virtual User SenderUser { get; set; } = null!;
}
