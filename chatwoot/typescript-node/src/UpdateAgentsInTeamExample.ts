import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.userApiKey, "USER_API_KEY");

const addNewAgentToTeamRequest: models.AddNewAgentToTeamRequest = {
  userIds: [
  ],
};

apiCaller.updateAgentsInTeam(
  0, // accountId
  0, // teamId
  addNewAgentToTeamRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling TeamsApi#updateAgentsInTeam:");
  console.log(error.body);
});
