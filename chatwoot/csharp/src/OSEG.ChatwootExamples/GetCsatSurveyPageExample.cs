using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class GetCsatSurveyPageExample
{
    public static void Run()
    {
        var config = new Configuration();

        try
        {
            new CSATSurveyPageApi(config).GetCsatSurveyPage(
                conversationUuid: null
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling CSATSurveyPageApi#GetCsatSurveyPage: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
