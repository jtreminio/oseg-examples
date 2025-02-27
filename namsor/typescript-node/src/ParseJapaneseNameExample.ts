import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.JapaneseApi();
apiCaller.setApiKey(api.JapaneseApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.parseJapaneseName(
  "小島 秀夫", // japaneseName
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling JapaneseApi#parseJapaneseName:");
  console.log(error.body);
});
