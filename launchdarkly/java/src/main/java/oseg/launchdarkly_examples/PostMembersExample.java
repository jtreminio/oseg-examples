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

public class PostMembersExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var newMemberForm1 = new NewMemberForm();
        newMemberForm1.email("sandy@acme.com");
        newMemberForm1.password("***");
        newMemberForm1.firstName("Ariel");
        newMemberForm1.lastName("Flores");
        newMemberForm1.role(NewMemberForm.RoleEnum.READER);
        newMemberForm1.customRoles(List.of (
            "customRole1",
            "customRole2"
        ));
        newMemberForm1.teamKeys(List.of (
            "team-1",
            "team-2"
        ));
        newMemberForm1.roleAttributes(null);

        var newMemberForm = new ArrayList<NewMemberForm>(List.of (
            newMemberForm1
        ));

        try
        {
            var response = new AccountMembersApi(config).postMembers(
                newMemberForm
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling AccountMembers#postMembers");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
