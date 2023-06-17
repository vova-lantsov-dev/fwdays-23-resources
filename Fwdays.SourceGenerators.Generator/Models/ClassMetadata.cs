using System.Collections.Generic;

namespace Fwdays.SourceGenerators.Generator.Models;

public class ClassMetadata
{
	public string Name { get; set; }
	public List<ClassMetadataProperty> Properties { get; set; }
}