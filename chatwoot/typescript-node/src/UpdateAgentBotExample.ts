import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.InboxesApi();
apiCaller.setApiKey(api.InboxesApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.InboxesApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.InboxesApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const updateAgentBotRequest: models.UpdateAgentBotRequest = {
  agentBot: 0,
};

apiCaller.updateAgentBot(
  0, // accountId
  0, // id
  updateAgentBotRequest, // data
).catch(error => {
  console.log("Exception when calling InboxesApi#updateAgentBot:");
  console.log(error.body);
});
