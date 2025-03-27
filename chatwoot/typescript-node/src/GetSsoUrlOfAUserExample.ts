import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.UsersApi();
apiCaller.setApiKey(api.UsersApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.getSsoUrlOfAUser(
  0, // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling UsersApi#getSsoUrlOfAUser:");
  console.log(error.body);
});
