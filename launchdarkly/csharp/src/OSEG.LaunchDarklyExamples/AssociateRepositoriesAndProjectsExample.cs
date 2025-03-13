using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class AssociateRepositoriesAndProjectsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var mappings1 = new InsightsRepositoryProject(
            repositoryKey: "launchdarkly/LaunchDarkly-Docs",
            projectKey: "default"
        );

        var mappings = new List<InsightsRepositoryProject>
        {
            mappings1,
        };

        var insightsRepositoryProjectMappings = new InsightsRepositoryProjectMappings(
            mappings: mappings
        );

        try
        {
            var response = new InsightsRepositoriesBetaApi(config).AssociateRepositoriesAndProjects(
                insightsRepositoryProjectMappings: insightsRepositoryProjectMappings
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InsightsRepositoriesBetaApi#AssociateRepositoriesAndProjects: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
