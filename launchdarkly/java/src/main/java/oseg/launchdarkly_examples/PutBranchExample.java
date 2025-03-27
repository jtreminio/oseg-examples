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

public class PutBranchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var references1Hunks1 = new HunkRep();
        references1Hunks1.startingLineNumber(45);
        references1Hunks1.lines("var enableFeature = 'enable-feature';");
        references1Hunks1.projKey("default");
        references1Hunks1.flagKey("enable-feature");
        references1Hunks1.aliases(List.of (
            "enableFeature",
            "EnableFeature"
        ));

        var references1Hunks = new ArrayList<HunkRep>(List.of (
            references1Hunks1
        ));

        var references1 = new ReferenceRep();
        references1.path("/main/index.js");
        references1.hint("javascript");
        references1.hunks(references1Hunks);

        var references = new ArrayList<ReferenceRep>(List.of (
            references1
        ));

        var putBranch = new PutBranch();
        putBranch.name("main");
        putBranch.head("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3");
        putBranch.syncTime(1706701522000L);
        putBranch.updateSequenceId(25L);
        putBranch.commitTime(1706701522000L);
        putBranch.references(references);

        try
        {
            new CodeReferencesApi(config).putBranch(
                "repo_string", // repo
                "branch_string", // branch
                putBranch
            );
        } catch (ApiException e) {
            System.err.println("Exception when calling CodeReferencesApi#putBranch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
