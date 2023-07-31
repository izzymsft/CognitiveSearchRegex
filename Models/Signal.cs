using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;

namespace CognitiveSearchRegexDemo.Models;

public class Signal
{
    [SimpleField(IsKey = true)]
    public string Id { get; set; }
    
    [SimpleField(IsFilterable = true, IsFacetable = true)]
    public string SourceType { get; set; }
    
    [SimpleField()]
    public string SourceName { get; set; }
    
    // This is the field with the Regex query issue
    [SearchableField(AnalyzerName = LexicalAnalyzerName.Values.EnLucene)]
    public string? UserTitle { get; set; }
    
    [SearchableField(AnalyzerName = LexicalAnalyzerName.Values.EnLucene)]
    public string? Description { get; set; }
}