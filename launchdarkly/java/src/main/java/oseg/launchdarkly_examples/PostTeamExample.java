package oseg.launchdarkly_examples;

import com.launchdarkly.client.ApiException;
import com.launchdarkly.client.Configuration;
import com.launchdarkly.client.api.*;
import com.launchdarkly.client.auth.*;
import com.launchdarkly.client.JSON;
import com.launchdarkly.client.model.*;

import java.io.File;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class PostTeamExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var teamPostInput = new TeamPostInput();
        teamPostInput.key("team-key-123abc");
        teamPostInput.name("Example team");
        teamPostInput.description("An example team");
        teamPostInput.customRoleKeys(List.of (
            "example-role1",
            "example-role2"
        ));
        teamPostInput.memberIDs(List.of (
            "12ab3c45de678910fgh12345"
        ));

        try
        {
            var response = new TeamsApi(config).postTeam(
                teamPostInput,
                null // expand
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling TeamsApi#postTeam");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
