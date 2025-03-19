import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AccountUsersApi();
apiCaller.setApiKey(api.AccountUsersApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const createAnAccountUserRequest: models.CreateAnAccountUserRequest = {
  role: "role_string",
  userId: 0,
};

apiCaller.createAnAccountUser(
  0, // accountId
  createAnAccountUserRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountUsersApi#createAnAccountUser:");
  console.log(error.body);
});
