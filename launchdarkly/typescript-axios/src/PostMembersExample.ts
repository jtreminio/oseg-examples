import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const newMemberForm1: api.NewMemberForm = {
  email: "sandy@acme.com",
  password: "***",
  firstName: "Ariel",
  lastName: "Flores",
  role: api.NewMemberFormRoleEnum.Reader,
  customRoles: [
    "customRole1",
    "customRole2",
  ],
  teamKeys: [
    "team-1",
    "team-2",
  ],
};

const newMemberForm = [
  newMemberForm1,
];

new api.AccountMembersApi(configuration).postMembers(
  newMemberForm,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountMembersApi#postMembers:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
