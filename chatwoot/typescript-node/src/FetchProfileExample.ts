import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ProfileApi();
apiCaller.setApiKey(api.ProfileApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ProfileApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ProfileApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.fetchProfile().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ProfileApi#fetchProfile:");
  console.log(error.body);
});
