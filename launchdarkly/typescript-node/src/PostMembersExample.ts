import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccountMembersApi();
apiCaller.setApiKey(api.AccountMembersApiApiKeys.ApiKey, "YOUR_API_KEY");

const newMemberForm1: models.NewMemberForm = {
  email: "sandy@acme.com",
  password: "***",
  firstName: "Ariel",
  lastName: "Flores",
  role: models.NewMemberForm.RoleEnum.Reader,
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

apiCaller.postMembers(
  newMemberForm,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountMembersApi#postMembers:");
  console.log(error.body);
});
