import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.PetApi(configuration).getPetById(
  12345, // petId
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PetApi#getPetById:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
