import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const user: api.User = {
  id: 12345,
  username: "my_user",
  firstName: "John",
  lastName: "Doe",
  email: "john@example.com",
  password: "secure_123",
  phone: "555-123-1234",
  userStatus: 1,
};

new api.UserApi(configuration).createUser(
  user,
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UserApi#createUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
