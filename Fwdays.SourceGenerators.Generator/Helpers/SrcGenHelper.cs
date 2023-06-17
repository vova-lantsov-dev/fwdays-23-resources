using System.Linq;
using System.Text;
using Fwdays.SourceGenerators.Generator.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Fwdays.SourceGenerators.Generator.Helpers;

public static class SrcGenHelper
{
	public static string GetContent(this ClassMetadata classMetadata)
	{
		var sb = new StringBuilder();

		sb.AppendLine("namespace Fwdays.SourceGenerators.ConsoleApp.Models2;");
		sb.AppendLine();

		sb.AppendFormat("public class {0}", classMetadata.Name);
		sb.AppendLine();
		sb.AppendLine("{");

		foreach (var property in classMetadata.Properties)
		{
			sb.AppendFormat("\tpublic {0} {1} {{ get; set; }}", property.Type, property.Name);
			sb.AppendLine();
		}

		sb.AppendLine("}");

		return sb.ToString();
	}

	public static string GetExtensionContent(string className)
	{
		var sb = new StringBuilder();

		sb.AppendLine("namespace Fwdays.SourceGenerators.ConsoleApp.Models;");
		sb.AppendLine();

		sb.AppendFormat("public static class {0}Extension", className);
		sb.AppendLine();
		sb.AppendLine("{");
		sb.AppendLine("\t// Empty extension class");
		sb.AppendLine("}");

		return sb.ToString();
	}

	public static bool IsClassOrRecordFromModelsNamespace(this SyntaxNode syntaxNode)
	{
			   // TypeDeclarationSyntax stands for interfaces, structs, classes and records
		return syntaxNode is TypeDeclarationSyntax typeDeclarationSyntax &&
			   
			   // Checking if node is either record or class
			   typeDeclarationSyntax.Keyword.ToString() is "record" or "class" &&
			   
			   // Checking if type (record or class) is public
			   typeDeclarationSyntax.Modifiers.Any(m => m.Text == "public") &&
			   
			   // Checking if type is NOT static
			   typeDeclarationSyntax.Modifiers.All(m => m.Text != "static") &&
			   
			   // Checking if type is a top-level class or record (e.g. class in class doesn't match)
			   typeDeclarationSyntax.Parent is BaseNamespaceDeclarationSyntax namespaceDeclarationSyntax &&
			   
			   // Checking if type's namespace contains 'Models' in its path
			   namespaceDeclarationSyntax.Name.ToString().Contains("Models");
	}
}