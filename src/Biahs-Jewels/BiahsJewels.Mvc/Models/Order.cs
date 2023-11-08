namespace BiahsJewels.Mvc.Models;

public class Order
{
    public int Id { get; set; }
    public int ConsumerId { get; set; }
    public string ConsumerContactNumber { get; set; }
    public Address? DeliveryAddress { get; set; }
    public string ModeOfPayment { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public DateTime DateCreated { get; set; }
    public string OrderStatus { get; set; }
    public decimal TotalPrice { get; set; }
}