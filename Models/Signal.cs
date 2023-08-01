using System.Text.Json.Serialization;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Newtonsoft.Json;

namespace CognitiveSearchRegexDemo.Models;

public class Signal
{
    [JsonPropertyName("Id")]
    [SimpleField(IsKey = true)]
    public string Id { get; set; }
    
    [JsonPropertyName("SourceType")]
    [SimpleField(IsFilterable = true, IsFacetable = true)]
    public string SourceType { get; set; }
    
    [JsonPropertyName("SourceName")]
    [SimpleField()]
    public string SourceName { get; set; }
    
    // This is the field with the Regex query issue
    [JsonPropertyName("UserTitle")]
    [SearchableField(AnalyzerName = LexicalAnalyzerName.Values.EnLucene)]
    public string? UserTitle { get; set; }
    
    // This is the field with the Regex query issue
    [JsonPropertyName("UserTitle2")]
    [SearchableField(IndexAnalyzerName = LexicalAnalyzerName.Values.Keyword, SearchAnalyzerName = LexicalAnalyzerName.Values.Keyword)]
    public string? UserTitle2{ get; set; }
    
    [JsonPropertyName("Description")]
    [SearchableField(AnalyzerName = LexicalAnalyzerName.Values.EnLucene)]
    public string? Description { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }

    public Signal()
    {
        this.Id = "";
        this.SourceType = "Commercial"; // or Consumer
        this.SourceName = "OpenAI";
        this.UserTitle2 = this.UserTitle;
    }
}