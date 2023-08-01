namespace CognitiveSearchRegexDemo.Services;

using System;
using Azure;
using Azure.Search.Documents;

public class BaseService
{
    protected readonly SearchClient client;
    protected BaseService()
    {
        string apiKey = Environment.GetEnvironmentVariable("SEARCH_API_KEY") ?? "";
        string endpointValue = Environment.GetEnvironmentVariable("SEARCH_ENDPOINT") ?? "";
        Uri endpoint = new Uri(endpointValue);
        string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX") ?? "";
        
        AzureKeyCredential credential = new AzureKeyCredential(apiKey);
        this.client = new SearchClient(endpoint, indexName, credential);
    }
}