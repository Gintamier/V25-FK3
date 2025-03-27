using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Item
{
    [Key]
    public int ItemID { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    public decimal UnitPrice { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}