import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const destinationPost: api.DestinationPost = {
  kind: api.DestinationPostKindEnum.GooglePubsub,
};

new api.DataExportDestinationsApi(configuration).postDestination(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  destinationPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling DataExportDestinationsApi#postDestination:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
