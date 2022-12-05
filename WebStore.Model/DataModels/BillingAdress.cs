namespace WebStore.Model.DataModels;
public class BillingAddress : Address
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = default!;
}