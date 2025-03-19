import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.FirstLastNameIn = {
  id: "9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4",
  firstName: "Keith",
  lastName: "Haring",
};

const personalNames = [
  personalNames1,
];

const batchFirstLastNameIn: models.BatchFirstLastNameIn = {
  personalNames: personalNames,
};

apiCaller.countryFnLnBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#countryFnLnBatch:");
  console.log(error.body);
});
