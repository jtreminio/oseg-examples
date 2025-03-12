import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.userApiKey, "USER_API_KEY");

const addNewAgentToTeamRequest = new models.AddNewAgentToTeamRequest();
addNewAgentToTeamRequest.userIds = [
];

apiCaller.addNewAgentToTeam(
  undefined, // accountId
  undefined, // teamId
  addNewAgentToTeamRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling TeamsApi#addNewAgentToTeam:");
  console.log(error.body);
});
