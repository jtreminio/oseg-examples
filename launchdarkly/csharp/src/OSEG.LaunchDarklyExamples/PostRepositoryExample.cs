using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostRepositoryExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var repositoryPost = new RepositoryPost(
            name: "LaunchDarkly-Docs",
            sourceLink: "https://github.com/launchdarkly/LaunchDarkly-Docs",
            commitUrlTemplate: "https://github.com/launchdarkly/LaunchDarkly-Docs/commit/${sha}",
            hunkUrlTemplate: "https://github.com/launchdarkly/LaunchDarkly-Docs/blob/${sha}/${filePath}#L${lineNumber}",
            type: RepositoryPost.TypeEnum.Github,
            defaultBranch: "main"
        );

        try
        {
            var response = new CodeReferencesApi(config).PostRepository(
                repositoryPost: repositoryPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling CodeReferencesApi#PostRepository: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
