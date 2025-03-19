import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AccountUsersApi();
apiCaller.setApiKey(api.AccountUsersApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const deleteAnAccountUserRequest: models.DeleteAnAccountUserRequest = {
  userId: 0,
};

apiCaller.deleteAnAccountUser(
  0, // accountId
  deleteAnAccountUserRequest, // data
).catch(error => {
  console.log("Exception when calling AccountUsersApi#deleteAnAccountUser:");
  console.log(error.body);
});
