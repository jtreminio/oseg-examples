import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNamesWithPhoneNumbers1: api.FirstLastNamePhoneNumberGeoIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Teniola",
  lastName: "Apata",
  phoneNumber: "08186472651",
  countryIso2: "NG",
  countryIso2Alt: "CI",
};

const personalNamesWithPhoneNumbers = [
  personalNamesWithPhoneNumbers1,
];

const batchFirstLastNamePhoneNumberGeoIn: api.BatchFirstLastNamePhoneNumberGeoIn = {
  personalNamesWithPhoneNumbers: personalNamesWithPhoneNumbers,
};

new api.SocialApi(configuration).phoneCodeGeoBatch(
  batchFirstLastNamePhoneNumberGeoIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SocialApi#phoneCodeGeoBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
