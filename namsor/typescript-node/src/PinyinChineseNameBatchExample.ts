import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.ChineseApi();
apiCaller.setApiKey(api.ChineseApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.PersonalNameIn();
personalNames1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42";
personalNames1.name = "赵丽颖";

const personalNames = [
  personalNames1,
];

const batchPersonalNameIn = new models.BatchPersonalNameIn();
batchPersonalNameIn.personalNames = personalNames;

apiCaller.pinyinChineseNameBatch(
  batchPersonalNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ChineseApi#pinyinChineseNameBatch:");
  console.log(error.body);
});
