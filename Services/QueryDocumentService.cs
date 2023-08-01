using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using CognitiveSearchRegexDemo.Models;

namespace CognitiveSearchRegexDemo.Services;

public class QueryDocumentService : BaseService
{
    public QueryDocumentService() : base()
    {
        
    }

    public void SearchAllDocuments()
    {
        int MaxResults = 3;

        SearchOptions options = new SearchOptions
        {
            Size = MaxResults
        };

        SearchResults<Signal> response = this.client.Search<Signal>("", options);

        foreach (var doc in response.GetResults())
        {
            Console.WriteLine(doc.Document.ToString());
        }
    }
    
    public void SearchWithRegex()
    {
        int MaxResults = 3;

        string searchRequest = "/[A-Za-z0-9]{1,}*/";
        
        SearchOptions options = new SearchOptions
        {
            SearchMode = SearchMode.Any,
            Size = MaxResults,
            Skip = 0,
            SearchFields = { "UserTitle2" }
        };

        SearchResults<Signal> response = this.client.Search<Signal>(searchRequest, options);

        foreach (var doc in response.GetResults())
        {
            Console.WriteLine(doc.Document.ToString());
        }
    }
}