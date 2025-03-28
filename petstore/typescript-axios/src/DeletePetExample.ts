import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  accessToken: "YOUR_ACCESS_TOKEN",
});

new api.PetApi(configuration).deletePet(
  12345, // petId
  "df560d5ba4eb7adbc635c87c3931a8421ae24dc81646196cd66544fd4471414a", // apiKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PetApi#deletePet:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
