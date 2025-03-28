import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const user: api.User = {
  id: 12345,
  username: "new-username",
  firstName: "Joe",
  lastName: "Broke",
  email: "some-email@example.com",
  password: "so secure omg",
  phone: "555-867-5309",
  userStatus: 1,
};

new api.UserApi(configuration).updateUser(
  "my-username", // username
  user,
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UserApi#updateUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
