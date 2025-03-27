import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AgentBotsApi();
apiCaller.setApiKey(api.AgentBotsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const agentBotCreateUpdatePayload: models.AgentBotCreateUpdatePayload = {
};

apiCaller.updateAnAgentBot(
  0, // id
  agentBotCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AgentBotsApi#updateAnAgentBot:");
  console.log(error.body);
});
