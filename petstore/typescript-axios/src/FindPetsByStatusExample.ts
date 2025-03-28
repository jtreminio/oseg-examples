import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  accessToken: "YOUR_ACCESS_TOKEN",
});

new api.PetApi(configuration).findPetsByStatus(
  [
    "available",
    "pending",
  ], // status
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PetApi#findPetsByStatus:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
