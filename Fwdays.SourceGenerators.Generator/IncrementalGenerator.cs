using System.Diagnostics;
using Fwdays.SourceGenerators.Generator.Helpers;
using Microsoft.CodeAnalysis;

namespace Fwdays.SourceGenerators.Generator;

[Generator]
public class IncrementalGenerator : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		//Debugger.Launch();
		
		var typesToInclude = context.SyntaxProvider.CreateSyntaxProvider(
			predicate: static (syntaxNode, _) => syntaxNode.IsClassOrRecordFromModelsNamespace(),
			transform: static (syntaxContext, _) => syntaxContext);

		context.RegisterSourceOutput(typesToInclude, static (sourceContext, item) =>
		{
			string className = item.SemanticModel.GetDeclaredSymbol(item.Node)!.Name;
			
			sourceContext.AddSource(className + "Extension",
				source: SrcGenHelper.GetExtensionContent(className));
		});
	}
}


// var jsonFile = context.AdditionalTextsProvider
// 	.Where(static text => text.Path.Contains("data.json"))
// 	.Select(static (text, _) => text.GetText()!.ToString());
//
// context.RegisterSourceOutput(jsonFile, static (sourceContext, fileContent) =>
// {
// 	var data = JsonSerializer.Deserialize<List<ClassMetadata>>(fileContent);
//
// 	foreach (ClassMetadata dataItem in data)
// 	{
// 		string content = dataItem.GetContent();
// 		sourceContext.AddSource(dataItem.Name, content);
// 	}
// });
