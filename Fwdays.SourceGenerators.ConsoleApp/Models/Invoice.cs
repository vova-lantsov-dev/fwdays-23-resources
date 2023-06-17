namespace Fwdays.SourceGenerators.ConsoleApp.Models;

public class Invoice
{
	public int Id { get; set; }
	public int OrderId { get; set; }
	public DateTime InvoiceDate { get; set; }
	public double TotalAmount { get; set; }
}