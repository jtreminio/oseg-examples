import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.JapaneseApi();
apiCaller.setApiKey(api.JapaneseApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.genderJapaneseNamePinyin(
  "中松", // japaneseSurname
  "義郎", // japaneseGivenName
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling JapaneseApi#genderJapaneseNamePinyin:");
  console.log(error.body);
});
