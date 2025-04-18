import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.GeneralApi();
apiCaller.setApiKey(api.GeneralApiApiKeys.api_key, "YOUR_API_KEY");

const properNouns1: models.NameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  name: "Zippo",
};

const properNouns = [
  properNouns1,
];

const batchNameIn: models.BatchNameIn = {
  properNouns: properNouns,
};

apiCaller.nameTypeBatch(
  batchNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling GeneralApi#nameTypeBatch:");
  console.log(error.body);
});
