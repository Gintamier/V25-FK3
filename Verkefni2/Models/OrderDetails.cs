using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderDetail
{
    [Key]
    public int OrderDetailID { get; set; }

    public int OrderID { get; set; }
    [ForeignKey("OrderID")]
    public Order Order { get; set; }

    public int ItemID { get; set; }
    [ForeignKey("ItemID")]
    public Item Item { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice => Quantity * Item.UnitPrice;
}