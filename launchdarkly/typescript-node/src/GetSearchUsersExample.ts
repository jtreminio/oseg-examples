import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UsersApi();
apiCaller.setApiKey(api.UsersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getSearchUsers(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // q
  undefined, // limit
  undefined, // offset
  undefined, // after
  undefined, // sort
  undefined, // searchAfter
  undefined, // filter
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling UsersApi#getSearchUsers:");
  console.log(error.body);
});
