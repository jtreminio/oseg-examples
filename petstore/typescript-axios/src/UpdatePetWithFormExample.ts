import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  accessToken: "YOUR_ACCESS_TOKEN",
});

new api.PetApi(configuration).updatePetWithForm(
  12345, // petId
  "Pet's new name", // name
  "sold", // status
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PetApi#updatePetWithForm:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
