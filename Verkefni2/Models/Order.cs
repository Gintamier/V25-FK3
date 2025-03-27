using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

public class Order
{
    [Key]
    public int OrderID { get; set; }

    public int SalesOrderNumber { get; set; }
    
    public DateTime SalesOrderDate { get; set; }

    public int CustomerNumber { get; set; }
    [ForeignKey("CustomerNumber")]
    public Customer Customer { get; set; }

    public int ClerkNumber { get; set; }
    [ForeignKey("ClerkNumber")]
    public Clerk Clerk { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}