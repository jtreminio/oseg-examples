import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CodeReferencesApi();
apiCaller.setApiKey(api.CodeReferencesApiApiKeys.ApiKey, "YOUR_API_KEY");

const references1Hunks1 = new models.HunkRep();
references1Hunks1.startingLineNumber = 45;
references1Hunks1.lines = "var enableFeature = 'enable-feature';";
references1Hunks1.projKey = "default";
references1Hunks1.flagKey = "enable-feature";
references1Hunks1.aliases = [
  "enableFeature",
  "EnableFeature",
];

const references1Hunks = [
  references1Hunks1,
];

const references1 = new models.ReferenceRep();
references1.path = "/main/index.js";
references1.hint = "javascript";
references1.hunks = references1Hunks;

const references = [
  references1,
];

const putBranch = new models.PutBranch();
putBranch.name = "main";
putBranch.head = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3";
putBranch.syncTime = 1706701522000;
putBranch.updateSequenceId = 25;
putBranch.commitTime = 1706701522000;
putBranch.references = references;

apiCaller.putBranch(
  "repo_string", // repo
  "branch_string", // branch
  putBranch,
).catch(error => {
  console.log("Exception when calling CodeReferencesApi#putBranch:");
  console.log(error.body);
});
