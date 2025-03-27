using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Clerk
{
    [Key]
    public int ClerkNumber { get; set; }
    
    [Required]
    public string ClerkName { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}