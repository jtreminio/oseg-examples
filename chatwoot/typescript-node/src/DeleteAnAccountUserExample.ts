import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AccountUsersApi();
apiCaller.setApiKey(api.AccountUsersApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const deleteAnAccountUserRequest = new models.DeleteAnAccountUserRequest();
deleteAnAccountUserRequest.userId = undefined;

apiCaller.deleteAnAccountUser(
  undefined, // accountId
  deleteAnAccountUserRequest, // data
).catch(error => {
  console.log("Exception when calling AccountUsersApi#deleteAnAccountUser:");
  console.log(error.body);
});
