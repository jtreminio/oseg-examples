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

public class PostAuditLogEntriesExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var statementPost1 = new StatementPost();
        statementPost1.effect(StatementPost.EffectEnum.ALLOW);
        statementPost1.resources(List.of (
            "proj/*:env/*:flag/*;testing-tag"
        ));
        statementPost1.notResources(List.of ());
        statementPost1.actions(List.of (
            "*"
        ));
        statementPost1.notActions(List.of ());

        var statementPost = new ArrayList<StatementPost>(List.of (
            statementPost1
        ));

        try
        {
            var response = new AuditLogApi(config).postAuditLogEntries(
                null, // before
                null, // after
                null, // q
                null, // limit
                statementPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling AuditLogApi#postAuditLogEntries");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
