using System.ComponentModel.DataAnnotations;

public class Table
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string TableName { get; set; } = string.Empty;

    public bool IsReserved { get; set; } = false;
}