import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.IndianApi();
apiCaller.setApiKey(api.IndianApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.FirstLastNameGeoSubdivisionIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
  countryIso2: "countryIso2",
  subdivisionIso: "subdivisionIso",
};

const personalNames2: models.FirstLastNameGeoSubdivisionIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
  countryIso2: "countryIso2",
  subdivisionIso: "subdivisionIso",
};

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchFirstLastNameGeoSubdivisionIn: models.BatchFirstLastNameGeoSubdivisionIn = {
  personalNames: personalNames,
};

apiCaller.casteIndianBatch(
  batchFirstLastNameGeoSubdivisionIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IndianApi#casteIndianBatch:");
  console.log(error.body);
});
