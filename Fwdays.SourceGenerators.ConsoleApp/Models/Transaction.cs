namespace Fwdays.SourceGenerators.ConsoleApp.Models;

public class Transaction
{
	public int Id { get; set; }
	public double Amount { get; set; }
	public DateTime TransactionDate { get; set; }
	public int UserId { get; set; }
}