import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const updateAgentInAccountRequest: api.UpdateAgentInAccountRequest = {
  role: api.UpdateAgentInAccountRequestRoleEnum.Agent,
};

new api.AgentsApi(configuration).updateAgentInAccount(
  0, // accountId
  0, // id
  updateAgentInAccountRequest, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AgentsApi#updateAgentInAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
