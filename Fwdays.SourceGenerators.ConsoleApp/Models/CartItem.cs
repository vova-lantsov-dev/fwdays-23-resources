namespace Fwdays.SourceGenerators.ConsoleApp.Models;

public class CartItem
{
	public int Id { get; set; }
	public int CartId { get; set; }
	public int ProductId { get; set; }
	public int Quantity { get; set; }
}