using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Customer
{
    [Key]
    public int CustomerNumber { get; set; }
    
    [Required]
    public string CustomerName { get; set; }
    
    public string CustomerAddress { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}