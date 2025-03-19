import * as fs from 'fs';
import api from "openapi_client"
import models from "openapi_client"

const apiCaller = new api.PetApi();
apiCaller.accessToken = "YOUR_ACCESS_TOKEN";

const category: models.Category = {
  id: 12345,
  name: "Category_Name",
};

const tags1: models.Tag = {
  id: 12345,
  name: "tag_1",
};

const tags2: models.Tag = {
  id: 98765,
  name: "tag_2",
};

const tags = [
  tags1,
  tags2,
];

const pet: models.Pet = {
  name: "My pet name",
  photoUrls: [
    "https://example.com/picture_1.jpg",
    "https://example.com/picture_2.jpg",
  ],
  id: 12345,
  status: models.Pet.StatusEnum.Available,
  category: category,
  tags: tags,
};

apiCaller.addPet(
  pet,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PetApi#addPet:");
  console.log(error.body);
});
