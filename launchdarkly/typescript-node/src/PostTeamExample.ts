import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.ApiKey, "YOUR_API_KEY");

const teamPostInput = new models.TeamPostInput();
teamPostInput.key = "team-key-123abc";
teamPostInput.name = "Example team";
teamPostInput.description = "An example team";
teamPostInput.customRoleKeys = [
  "example-role1",
  "example-role2",
];
teamPostInput.memberIDs = [
  "12ab3c45de678910fgh12345",
];

apiCaller.postTeam(
  teamPostInput,
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Teams#postTeam:");
  console.log(error.body);
});
