using System.Collections.Generic;
using System.Linq;
using Fwdays.SourceGenerators.Generator.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Fwdays.SourceGenerators.Generator;

//[Generator]
public class SourceGenerator : ISourceGenerator
{
	public void Initialize(GeneratorInitializationContext context) =>
		context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());

	public void Execute(GeneratorExecutionContext context)
	{
		if (context.SyntaxReceiver is not SyntaxReceiver syntaxReceiver)
			return;

		var typesToInclude = syntaxReceiver.TypesToInclude;
		// ...
	}
}

public class SyntaxReceiver : ISyntaxReceiver
{
	public List<TypeDeclarationSyntax> TypesToInclude { get; } = new();

	public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
	{
		if (syntaxNode is TypeDeclarationSyntax typeDeclarationSyntax &&
			syntaxNode.IsClassOrRecordFromModelsNamespace())
		{
			TypesToInclude.Add(typeDeclarationSyntax);
		}
	}
}