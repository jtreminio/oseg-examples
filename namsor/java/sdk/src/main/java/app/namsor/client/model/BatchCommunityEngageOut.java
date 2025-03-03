/*
 * NamSor API v2
 * NamSor API v2 : enpoints to process personal names (gender, cultural origin or ethnicity) in all alphabets or languages. By default, enpoints use 1 unit per name (ex. Gender), but Ethnicity classification uses 10 to 20 units per name depending on taxonomy. Use GET methods for small tests, but prefer POST methods for higher throughput (batch processing of up to 100 names at a time). Need something you can't find here? We have many more features coming soon. Let us know, we'll do our best to add it! 
 *
 * The version of the OpenAPI document: 2.0.29
 * Contact: contact@namsor.com
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


package app.namsor.client.model;

import java.util.Objects;
import app.namsor.client.model.CommunityEngageOut;
import com.google.gson.TypeAdapter;
import com.google.gson.annotations.JsonAdapter;
import com.google.gson.annotations.SerializedName;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonArray;
import com.google.gson.JsonDeserializationContext;
import com.google.gson.JsonDeserializer;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParseException;
import com.google.gson.TypeAdapterFactory;
import com.google.gson.reflect.TypeToken;
import com.google.gson.TypeAdapter;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import java.io.IOException;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import app.namsor.client.JSON;

/**
 * BatchCommunityEngageOut
 */
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen", comments = "Generator version: 7.11.0")
public class BatchCommunityEngageOut {
  public static final String SERIALIZED_NAME_ENGAGEMENT_CANDIDATES = "engagementCandidates";
  @SerializedName(SERIALIZED_NAME_ENGAGEMENT_CANDIDATES)
  @javax.annotation.Nullable
  private List<CommunityEngageOut> engagementCandidates = new ArrayList<>();

  public BatchCommunityEngageOut() {
  }

  public BatchCommunityEngageOut engagementCandidates(@javax.annotation.Nullable List<CommunityEngageOut> engagementCandidates) {
    this.engagementCandidates = engagementCandidates;
    return this;
  }

  public BatchCommunityEngageOut addEngagementCandidatesItem(CommunityEngageOut engagementCandidatesItem) {
    if (this.engagementCandidates == null) {
      this.engagementCandidates = new ArrayList<>();
    }
    this.engagementCandidates.add(engagementCandidatesItem);
    return this;
  }

  /**
   * Classified community engagement candidates
   * @return engagementCandidates
   */
  @javax.annotation.Nullable
  public List<CommunityEngageOut> getEngagementCandidates() {
    return engagementCandidates;
  }

  public void setEngagementCandidates(@javax.annotation.Nullable List<CommunityEngageOut> engagementCandidates) {
    this.engagementCandidates = engagementCandidates;
  }



  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    BatchCommunityEngageOut batchCommunityEngageOut = (BatchCommunityEngageOut) o;
    return Objects.equals(this.engagementCandidates, batchCommunityEngageOut.engagementCandidates);
  }

  @Override
  public int hashCode() {
    return Objects.hash(engagementCandidates);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class BatchCommunityEngageOut {\n");
    sb.append("    engagementCandidates: ").append(toIndentedString(engagementCandidates)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }


  public static HashSet<String> openapiFields;
  public static HashSet<String> openapiRequiredFields;

  static {
    // a set of all properties/fields (JSON key names)
    openapiFields = new HashSet<String>();
    openapiFields.add("engagementCandidates");

    // a set of required properties/fields (JSON key names)
    openapiRequiredFields = new HashSet<String>();
  }

  /**
   * Validates the JSON Element and throws an exception if issues found
   *
   * @param jsonElement JSON Element
   * @throws IOException if the JSON Element is invalid with respect to BatchCommunityEngageOut
   */
  public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      if (jsonElement == null) {
        if (!BatchCommunityEngageOut.openapiRequiredFields.isEmpty()) { // has required fields but JSON element is null
          throw new IllegalArgumentException(String.format("The required field(s) %s in BatchCommunityEngageOut is not found in the empty JSON string", BatchCommunityEngageOut.openapiRequiredFields.toString()));
        }
      }

      Set<Map.Entry<String, JsonElement>> entries = jsonElement.getAsJsonObject().entrySet();
      // check to see if the JSON string contains additional fields
      for (Map.Entry<String, JsonElement> entry : entries) {
        if (!BatchCommunityEngageOut.openapiFields.contains(entry.getKey())) {
          throw new IllegalArgumentException(String.format("The field `%s` in the JSON string is not defined in the `BatchCommunityEngageOut` properties. JSON: %s", entry.getKey(), jsonElement.toString()));
        }
      }
        JsonObject jsonObj = jsonElement.getAsJsonObject();
      if (jsonObj.get("engagementCandidates") != null && !jsonObj.get("engagementCandidates").isJsonNull()) {
        JsonArray jsonArrayengagementCandidates = jsonObj.getAsJsonArray("engagementCandidates");
        if (jsonArrayengagementCandidates != null) {
          // ensure the json data is an array
          if (!jsonObj.get("engagementCandidates").isJsonArray()) {
            throw new IllegalArgumentException(String.format("Expected the field `engagementCandidates` to be an array in the JSON string but got `%s`", jsonObj.get("engagementCandidates").toString()));
          }

          // validate the optional field `engagementCandidates` (array)
          for (int i = 0; i < jsonArrayengagementCandidates.size(); i++) {
            CommunityEngageOut.validateJsonElement(jsonArrayengagementCandidates.get(i));
          };
        }
      }
  }

  public static class CustomTypeAdapterFactory implements TypeAdapterFactory {
    @SuppressWarnings("unchecked")
    @Override
    public <T> TypeAdapter<T> create(Gson gson, TypeToken<T> type) {
       if (!BatchCommunityEngageOut.class.isAssignableFrom(type.getRawType())) {
         return null; // this class only serializes 'BatchCommunityEngageOut' and its subtypes
       }
       final TypeAdapter<JsonElement> elementAdapter = gson.getAdapter(JsonElement.class);
       final TypeAdapter<BatchCommunityEngageOut> thisAdapter
                        = gson.getDelegateAdapter(this, TypeToken.get(BatchCommunityEngageOut.class));

       return (TypeAdapter<T>) new TypeAdapter<BatchCommunityEngageOut>() {
           @Override
           public void write(JsonWriter out, BatchCommunityEngageOut value) throws IOException {
             JsonObject obj = thisAdapter.toJsonTree(value).getAsJsonObject();
             elementAdapter.write(out, obj);
           }

           @Override
           public BatchCommunityEngageOut read(JsonReader in) throws IOException {
             JsonElement jsonElement = elementAdapter.read(in);
             validateJsonElement(jsonElement);
             return thisAdapter.fromJsonTree(jsonElement);
           }

       }.nullSafe();
    }
  }

  /**
   * Create an instance of BatchCommunityEngageOut given an JSON string
   *
   * @param jsonString JSON string
   * @return An instance of BatchCommunityEngageOut
   * @throws IOException if the JSON string is invalid with respect to BatchCommunityEngageOut
   */
  public static BatchCommunityEngageOut fromJson(String jsonString) throws IOException {
    return JSON.getGson().fromJson(jsonString, BatchCommunityEngageOut.class);
  }

  /**
   * Convert an instance of BatchCommunityEngageOut to an JSON string
   *
   * @return JSON string
   */
  public String toJson() {
    return JSON.getGson().toJson(this);
  }
}

