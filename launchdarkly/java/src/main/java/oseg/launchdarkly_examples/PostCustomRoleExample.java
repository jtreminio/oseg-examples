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

public class PostCustomRoleExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var policy1 = new StatementPost();
        policy1.effect(StatementPost.EffectEnum.ALLOW);
        policy1.resources(List.of (
            "proj/*:env/production:flag/*"
        ));
        policy1.actions(List.of (
            "updateOn"
        ));

        var policy = new ArrayList<StatementPost>(List.of (
            policy1
        ));

        var customRolePost = new CustomRolePost();
        customRolePost.name("Ops team");
        customRolePost.key("role-key-123abc");
        customRolePost.description("An example role for members of the ops team");
        customRolePost.basePermissions("reader");
        customRolePost.policy(policy);

        try
        {
            var response = new CustomRolesApi(config).postCustomRole(
                customRolePost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling CustomRolesApi#postCustomRole");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
