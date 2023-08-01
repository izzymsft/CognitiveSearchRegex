using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using CognitiveSearchRegexDemo.Models;

namespace CognitiveSearchRegexDemo.Services;

using System;
using Azure;
using Azure.Search.Documents;
public class ListIndexService
{
    private readonly SearchIndexClient _searchIndexClient;
    
    public ListIndexService()
    {
        string apiKey = Environment.GetEnvironmentVariable("SEARCH_API_KEY") ?? "";
        string searchEndpoint = Environment.GetEnvironmentVariable("SEARCH_ENDPOINT") ?? "";
        Uri? endpoint = new Uri(searchEndpoint);

        AzureKeyCredential credential = new AzureKeyCredential(apiKey);
        this._searchIndexClient = new SearchIndexClient(endpoint, credential);
    }


    public Pageable<SearchIndex> listIndices()
    {

        string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX") ?? "";

        // Create the index using FieldBuilder.
        SearchIndex index = new SearchIndex(indexName)
        {
            Fields = new FieldBuilder().Build(typeof(Signal)),
        };

        var response = this._searchIndexClient.GetIndexes();

        foreach (var page in response)
        {
            Console.WriteLine(page.ToString());
        }
        
        return response;
    }
}