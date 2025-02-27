import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.PersonalNameIn();
personalNames1.id = "0f472330-11a9-49ad-a0f5-bcac90a3f6bf";
personalNames1.name = "Keith Haring";

const personalNames = [
  personalNames1,
];

const batchPersonalNameIn = new models.BatchPersonalNameIn();
batchPersonalNameIn.personalNames = personalNames;

apiCaller.genderFullBatch(
  batchPersonalNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#genderFullBatch:");
  console.log(error.body);
});
