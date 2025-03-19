import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.SocialApi();
apiCaller.setApiKey(api.SocialApiApiKeys.api_key, "YOUR_API_KEY");

const personalNamesWithPhoneNumbers1: models.FirstLastNamePhoneNumberIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Jamini",
  lastName: "Roy",
  phoneNumber: "09804201420",
};

const personalNamesWithPhoneNumbers = [
  personalNamesWithPhoneNumbers1,
];

const batchFirstLastNamePhoneNumberIn: models.BatchFirstLastNamePhoneNumberIn = {
  personalNamesWithPhoneNumbers: personalNamesWithPhoneNumbers,
};

apiCaller.phoneCodeBatch(
  batchFirstLastNamePhoneNumberIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SocialApi#phoneCodeBatch:");
  console.log(error.body);
});
