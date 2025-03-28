import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const accessTokenPost: api.AccessTokenPost = {
  role: api.AccessTokenPostRoleEnum.Reader,
};

new api.AccessTokensApi(configuration).postToken(
  accessTokenPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccessTokensApi#postToken:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
