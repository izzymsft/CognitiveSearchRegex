using CognitiveSearchRegexDemo.Models;
using System;
using System.Collections.Generic;

namespace CognitiveSearchRegexDemo.Services;

public class AddDocumentService : BaseService
{
    public AddDocumentService(): base()
    {
        
    }


    public void AddDocuments()
    {
        List<Signal> documents = new List<Signal>();

        documents.Add(new Signal{Id = "12315", Description = "This is an Example", SourceName = "Microsoft", SourceType = "Commercial", UserTitle = "Storm-0557 Vulnerability", UserTitle2 = "Storm-0557 Vulnerability"});
        documents.Add(new Signal{Id = "12316", Description = "This is an Elephant", SourceName = "OpenAI", SourceType = "Commercial", UserTitle = "Storm-0558 Vulnerability", UserTitle2 = "Storm-0558 Vulnerability"});
        documents.Add(new Signal{Id = "12317", Description = "This is the FIFA Women's World Cup Round of 16", SourceName = "NVIDIA", SourceType = "Commercial", UserTitle = "Storm-0559 Vulnerability", UserTitle2 = "Storm-0559 Vulnerability"});
        
        var response = this.client.MergeOrUploadDocuments(documents);
    }

    public void DeleteDocuments()
    {
        Signal[] documents = { new Signal{ Id="12345" } };
        var response = this.client.DeleteDocuments(documents);
    }
}