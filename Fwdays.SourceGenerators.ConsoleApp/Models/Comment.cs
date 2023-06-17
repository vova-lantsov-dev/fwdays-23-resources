namespace Fwdays.SourceGenerators.ConsoleApp.Models;

public class Comment
{
	public int Id { get; set; }
	public string Content { get; set; }
	public DateTime DatePosted { get; set; }
	public int BlogPostId { get; set; }
}