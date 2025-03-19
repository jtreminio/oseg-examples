import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AccountAgentBotsApi();
apiCaller.setApiKey(api.AccountAgentBotsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.AccountAgentBotsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.AccountAgentBotsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.listAllAccountAgentBots(
  0, // accountId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountAgentBotsApi#listAllAccountAgentBots:");
  console.log(error.body);
});
