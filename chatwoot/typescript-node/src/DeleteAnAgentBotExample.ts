import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AgentBotsApi();
apiCaller.setApiKey(api.AgentBotsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.deleteAnAgentBot(
  0, // id
).catch(error => {
  console.log("Exception when calling AgentBotsApi#deleteAnAgentBot:");
  console.log(error.body);
});
