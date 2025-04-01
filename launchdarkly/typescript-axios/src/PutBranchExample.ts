import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const references1Hunks1: api.HunkRep = {
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

const references1: api.ReferenceRep = {
  path: "/main/index.js",
  hint: "javascript",
  hunks: references1Hunks,
};

const references = [
  references1,
];

const putBranch: api.PutBranch = {
  name: "main",
  head: "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
  syncTime: 1706701522000,
  updateSequenceId: 25,
  commitTime: 1706701522000,
  references: references,
};

new api.CodeReferencesApi(configuration).putBranch(
  "repo_string", // repo
  "branch_string", // branch
  putBranch,
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CodeReferencesApi#putBranch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
