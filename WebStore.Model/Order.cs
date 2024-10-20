using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Orders")]
public class Order
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    [Required]
    public DateTime DeliveryDate { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public double TotalAmount { get; set; }

    [Required]
    public long TrackingNumber { get; set; }
}
