using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Reservation
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public DateTime ReservationDate { get; set; }

    // เชื่อมกับ Table
    [ForeignKey("Table")]
    public int TableId { get; set; }
    public Table? Table { get; set; }
}