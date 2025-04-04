import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.TeamsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.TeamsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.deleteATeam(
  0, // accountId
  0, // teamId
).catch(error => {
  console.log("Exception when calling TeamsApi#deleteATeam:");
  console.log(error.body);
});
