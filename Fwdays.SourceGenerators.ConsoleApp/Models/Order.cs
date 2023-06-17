namespace Fwdays.SourceGenerators.ConsoleApp.Models;

public class Order
{
	public int Id { get; set; }
	public int UserId { get; set; }
	public DateTime OrderDate { get; set; }
	public double TotalPrice { get; set; }
}