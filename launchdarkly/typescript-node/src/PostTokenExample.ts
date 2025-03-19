import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccessTokensApi();
apiCaller.setApiKey(api.AccessTokensApiApiKeys.ApiKey, "YOUR_API_KEY");

const accessTokenPost: models.AccessTokenPost = {
  role: models.AccessTokenPost.RoleEnum.Reader,
};

apiCaller.postToken(
  accessTokenPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccessTokensApi#postToken:");
  console.log(error.body);
});
