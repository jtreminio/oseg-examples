package oseg.launchdarkly_examples;

import com.launchdarkly.client.ApiException;
import com.launchdarkly.client.Configuration;
import com.launchdarkly.client.api.*;
import com.launchdarkly.client.auth.*;
import com.launchdarkly.client.JSON;
import com.launchdarkly.client.model.*;

import java.io.File;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class PostRepositoryExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var repositoryPost = new RepositoryPost();
        repositoryPost.name("LaunchDarkly-Docs");
        repositoryPost.sourceLink("https://github.com/launchdarkly/LaunchDarkly-Docs");
        repositoryPost.commitUrlTemplate("https://github.com/launchdarkly/LaunchDarkly-Docs/commit/${sha}");
        repositoryPost.hunkUrlTemplate("https://github.com/launchdarkly/LaunchDarkly-Docs/blob/${sha}/${filePath}#L${lineNumber}");
        repositoryPost.type(RepositoryPost.TypeEnum.GITHUB);
        repositoryPost.defaultBranch("main");

        try
        {
            var response = new CodeReferencesApi(config).postRepository(
                repositoryPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling CodeReferencesApi#postRepository");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
