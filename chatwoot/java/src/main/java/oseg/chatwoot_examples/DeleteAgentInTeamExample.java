package oseg.chatwoot_examples;

import com.chatwoot.client.ApiException;
import com.chatwoot.client.Configuration;
import com.chatwoot.client.api.*;
import com.chatwoot.client.auth.*;
import com.chatwoot.client.JSON;
import com.chatwoot.client.model.*;

import java.io.File;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class DeleteAgentInTeamExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("USER_API_KEY");

        var deleteAgentInTeamRequest = new DeleteAgentInTeamRequest();
        deleteAgentInTeamRequest.userIds(List.of ());

        try
        {
            new TeamsApi(config).deleteAgentInTeam(
                null, // accountId
                null, // teamId
                deleteAgentInTeamRequest // data
            );
        } catch (ApiException e) {
            System.err.println("Exception when calling TeamsApi#deleteAgentInTeam");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
