// See https://aka.ms/new-console-template for more information

using CognitiveSearchRegexDemo.Services;

namespace CognitiveSearchRegexDemo
{
    
}
class Program
{
    private static void ListIndices()
    {
        ListIndexService listIndexService = new ListIndexService();
        
        var indices = listIndexService.listIndices();
    }

    private static void DeleteIndex()
    {
        CreateIndexService createIndexService = new CreateIndexService();
        
        createIndexService.deleteIndex();
    }
    
    private static void CreateIndex()
    {
        CreateIndexService createIndexService = new CreateIndexService();
        
        createIndexService.createIndex();
    }

    private static void AddDocs()
    {
        AddDocumentService addDocumentService = new AddDocumentService();
            
        addDocumentService.AddDocuments(); 
    }
    
    private static void DeleteDocs()
    {
        AddDocumentService addDocumentService = new AddDocumentService();
            
        addDocumentService.DeleteDocuments();
    }

    private static void SearchIndex()
    {
        QueryDocumentService service = new QueryDocumentService();
        
        service.SearchAllDocuments();
    }
    
    private static void QueryRegex()
    {
        QueryDocumentService service = new QueryDocumentService();
        
        service.SearchWithRegex();
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Search!");

        //DeleteIndex();
        
        //CreateIndex();
        
        //DeleteDocs();

        //AddDocs();

        QueryRegex();
    }
}
