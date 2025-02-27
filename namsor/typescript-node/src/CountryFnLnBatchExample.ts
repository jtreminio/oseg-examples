import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.FirstLastNameIn();
personalNames1.id = "9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4";
personalNames1.firstName = "Keith";
personalNames1.lastName = "Haring";

const personalNames = [
  personalNames1,
];

const batchFirstLastNameIn = new models.BatchFirstLastNameIn();
batchFirstLastNameIn.personalNames = personalNames;

apiCaller.countryFnLnBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#countryFnLnBatch:");
  console.log(error.body);
});
