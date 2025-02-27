import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.FirstLastNameIn();
personalNames1.id = "b590b04c-da23-4f2f-a334-aee384ee420a";
personalNames1.firstName = "Keith";
personalNames1.lastName = "Haring";

const personalNames = [
  personalNames1,
];

const batchFirstLastNameIn = new models.BatchFirstLastNameIn();
batchFirstLastNameIn.personalNames = personalNames;

apiCaller.genderBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#genderBatch:");
  console.log(error.body);
});
