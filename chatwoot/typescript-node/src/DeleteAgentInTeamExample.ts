import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.userApiKey, "USER_API_KEY");

const deleteAgentInTeamRequest = new models.DeleteAgentInTeamRequest();
deleteAgentInTeamRequest.userIds = [
];

apiCaller.deleteAgentInTeam(
  undefined, // accountId
  undefined, // teamId
  deleteAgentInTeamRequest, // data
).catch(error => {
  console.log("Exception when calling TeamsApi#deleteAgentInTeam:");
  console.log(error.body);
});
