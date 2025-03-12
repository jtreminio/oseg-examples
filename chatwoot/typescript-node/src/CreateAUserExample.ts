import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.UsersApi();
apiCaller.setApiKey(api.UsersApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const userCreateUpdatePayload = new models.UserCreateUpdatePayload();
userCreateUpdatePayload.name = undefined;
userCreateUpdatePayload.email = undefined;
userCreateUpdatePayload.password = undefined;

apiCaller.createAUser(
  userCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling UsersApi#createAUser:");
  console.log(error.body);
});
