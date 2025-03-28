import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const addNewAgentToAccountRequest: api.AddNewAgentToAccountRequest = {
  email: "email_string",
  name: "name_string",
  role: api.AddNewAgentToAccountRequestRoleEnum.Agent,
};

new api.AgentsApi(configuration).addNewAgentToAccount(
  0, // accountId
  addNewAgentToAccountRequest, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AgentsApi#addNewAgentToAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
