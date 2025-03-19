import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CodeReferencesApi();
apiCaller.setApiKey(api.CodeReferencesApiApiKeys.ApiKey, "YOUR_API_KEY");

const references1Hunks1: models.HunkRep = {
  startingLineNumber: 45,
  lines: "var enableFeature = 'enable-feature';",
  projKey: "default",
  flagKey: "enable-feature",
  aliases: [
    "enableFeature",
    "EnableFeature",
  ],
};

const references1Hunks = [
  references1Hunks1,
];

const references1: models.ReferenceRep = {
  path: "/main/index.js",
  hint: "javascript",
  hunks: references1Hunks,
};

const references = [
  references1,
];

const putBranch: models.PutBranch = {
  name: "main",
  head: "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
  syncTime: 1706701522000,
  updateSequenceId: 25,
  commitTime: 1706701522000,
  references: references,
};

apiCaller.putBranch(
  "repo_string", // repo
  "branch_string", // branch
  putBranch,
).catch(error => {
  console.log("Exception when calling CodeReferencesApi#putBranch:");
  console.log(error.body);
});
