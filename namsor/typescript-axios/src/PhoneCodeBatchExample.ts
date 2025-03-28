import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNamesWithPhoneNumbers1: api.FirstLastNamePhoneNumberIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Jamini",
  lastName: "Roy",
  phoneNumber: "09804201420",
};

const personalNamesWithPhoneNumbers = [
  personalNamesWithPhoneNumbers1,
];

const batchFirstLastNamePhoneNumberIn: api.BatchFirstLastNamePhoneNumberIn = {
  personalNamesWithPhoneNumbers: personalNamesWithPhoneNumbers,
};

new api.SocialApi(configuration).phoneCodeBatch(
  batchFirstLastNamePhoneNumberIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SocialApi#phoneCodeBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
