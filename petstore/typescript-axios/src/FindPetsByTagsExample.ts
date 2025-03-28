import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  accessToken: "YOUR_ACCESS_TOKEN",
});

new api.PetApi(configuration).findPetsByTags(
  [
    "tag_1",
    "tag_2",
  ], // tags
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PetApi#findPetsByTags:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
