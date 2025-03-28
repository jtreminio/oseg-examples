import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  accessToken: "YOUR_ACCESS_TOKEN",
});

new api.PetApi(configuration).uploadFile(
  12345, // petId
  "Additional data to pass to server", // additionalMetadata
  new File(["contents of file"], "/path/to/file"), // file
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PetApi#uploadFile:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
