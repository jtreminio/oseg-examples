import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.TeamsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.TeamsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const teamCreateUpdatePayload: models.TeamCreateUpdatePayload = {
};

apiCaller.updateATeam(
  0, // accountId
  0, // teamId
  teamCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling TeamsApi#updateATeam:");
  console.log(error.body);
});
