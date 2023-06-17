namespace Fwdays.SourceGenerators.ConsoleApp.Models;

public class ShippingDetail
{
	public int Id { get; set; }
	public int OrderId { get; set; }
	public int AddressId { get; set; }
	public DateTime EstimatedDelivery { get; set; }
}