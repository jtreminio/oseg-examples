import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.CustomAttributesApi();
apiCaller.setApiKey(api.CustomAttributesApiApiKeys.userApiKey, "USER_API_KEY");

apiCaller.deleteCustomAttributeFromAccount(
  undefined, // accountId
  undefined, // id
).catch(error => {
  console.log("Exception when calling CustomAttributesApi#deleteCustomAttributeFromAccount:");
  console.log(error.body);
});
