import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.JapaneseApi();
apiCaller.setApiKey(api.JapaneseApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.japaneseNameMatchFeedbackLoop(
  "Tessai", // japaneseSurnameLatin
  "Tomioka", // japaneseGivenNameLatin
  "富岡 鉄斎", // japaneseName
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling JapaneseApi#japaneseNameMatchFeedbackLoop:");
  console.log(error.body);
});
