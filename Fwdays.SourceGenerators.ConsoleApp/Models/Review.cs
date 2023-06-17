namespace Fwdays.SourceGenerators.ConsoleApp.Models;

public class Review
{
	public int Id { get; set; }
	public int ProductId { get; set; }
	public int UserId { get; set; }
	public string Content { get; set; }
	public int Rating { get; set; }
}