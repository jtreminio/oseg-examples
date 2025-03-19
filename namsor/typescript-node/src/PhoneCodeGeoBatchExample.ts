import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.SocialApi();
apiCaller.setApiKey(api.SocialApiApiKeys.api_key, "YOUR_API_KEY");

const personalNamesWithPhoneNumbers1: models.FirstLastNamePhoneNumberGeoIn = {
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

const batchFirstLastNamePhoneNumberGeoIn: models.BatchFirstLastNamePhoneNumberGeoIn = {
  personalNamesWithPhoneNumbers: personalNamesWithPhoneNumbers,
};

apiCaller.phoneCodeGeoBatch(
  batchFirstLastNamePhoneNumberGeoIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SocialApi#phoneCodeGeoBatch:");
  console.log(error.body);
});
