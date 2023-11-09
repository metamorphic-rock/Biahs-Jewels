namespace BiahsJewels.Mvc.Models;

public class Address
{
    public int Id { get; set; }
    public string PrimaryAddress { get; set; }
    public string? SecondaryAddress { get; set; }
    public int ConsumerId { get; set; }
}
