import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.GeneralApi();
apiCaller.setApiKey(api.GeneralApiApiKeys.api_key, "YOUR_API_KEY");

const properNouns1 = new models.NameGeoIn();
properNouns1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42";
properNouns1.name = "Edi Gathegi";
properNouns1.countryIso2 = "KE";

const properNouns = [
  properNouns1,
];

const batchNameGeoIn = new models.BatchNameGeoIn();
batchNameGeoIn.properNouns = properNouns;

apiCaller.nameTypeGeoBatch(
  batchNameGeoIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling GeneralApi#nameTypeGeoBatch:");
  console.log(error.body);
});
