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
 * Represents the output of inferring the LIKELY caste from a personal Hindu/Indian name.
 */
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen", comments = "Generator version: 7.11.0")
public class FirstLastNameCasteOut {
  public static final String SERIALIZED_NAME_SCRIPT = "script";
  @SerializedName(SERIALIZED_NAME_SCRIPT)
  @javax.annotation.Nullable
  private String script;

  public static final String SERIALIZED_NAME_ID = "id";
  @SerializedName(SERIALIZED_NAME_ID)
  @javax.annotation.Nullable
  private String id;

  public static final String SERIALIZED_NAME_EXPLANATION = "explanation";
  @SerializedName(SERIALIZED_NAME_EXPLANATION)
  @javax.annotation.Nullable
  private String explanation;

  public static final String SERIALIZED_NAME_FIRST_NAME = "firstName";
  @SerializedName(SERIALIZED_NAME_FIRST_NAME)
  @javax.annotation.Nullable
  private String firstName;

  public static final String SERIALIZED_NAME_LAST_NAME = "lastName";
  @SerializedName(SERIALIZED_NAME_LAST_NAME)
  @javax.annotation.Nullable
  private String lastName;

  public static final String SERIALIZED_NAME_CASTE = "caste";
  @SerializedName(SERIALIZED_NAME_CASTE)
  @javax.annotation.Nullable
  private String caste;

  public static final String SERIALIZED_NAME_CASTE_ALT = "casteAlt";
  @SerializedName(SERIALIZED_NAME_CASTE_ALT)
  @javax.annotation.Nullable
  private String casteAlt;

  public static final String SERIALIZED_NAME_CASTE_TOP = "casteTop";
  @SerializedName(SERIALIZED_NAME_CASTE_TOP)
  @javax.annotation.Nullable
  private List<String> casteTop = new ArrayList<>();

  public static final String SERIALIZED_NAME_SCORE = "score";
  @SerializedName(SERIALIZED_NAME_SCORE)
  @javax.annotation.Nullable
  private Double score;

  public static final String SERIALIZED_NAME_PROBABILITY_CALIBRATED = "probabilityCalibrated";
  @SerializedName(SERIALIZED_NAME_PROBABILITY_CALIBRATED)
  @javax.annotation.Nullable
  private Double probabilityCalibrated;

  public static final String SERIALIZED_NAME_PROBABILITY_ALT_CALIBRATED = "probabilityAltCalibrated";
  @SerializedName(SERIALIZED_NAME_PROBABILITY_ALT_CALIBRATED)
  @javax.annotation.Nullable
  private Double probabilityAltCalibrated;

  public FirstLastNameCasteOut() {
  }

  public FirstLastNameCasteOut script(@javax.annotation.Nullable String script) {
    this.script = script;
    return this;
  }

  /**
   * Get script
   * @return script
   */
  @javax.annotation.Nullable
  public String getScript() {
    return script;
  }

  public void setScript(@javax.annotation.Nullable String script) {
    this.script = script;
  }


  public FirstLastNameCasteOut id(@javax.annotation.Nullable String id) {
    this.id = id;
    return this;
  }

  /**
   * Get id
   * @return id
   */
  @javax.annotation.Nullable
  public String getId() {
    return id;
  }

  public void setId(@javax.annotation.Nullable String id) {
    this.id = id;
  }


  public FirstLastNameCasteOut explanation(@javax.annotation.Nullable String explanation) {
    this.explanation = explanation;
    return this;
  }

  /**
   * Get explanation
   * @return explanation
   */
  @javax.annotation.Nullable
  public String getExplanation() {
    return explanation;
  }

  public void setExplanation(@javax.annotation.Nullable String explanation) {
    this.explanation = explanation;
  }


  public FirstLastNameCasteOut firstName(@javax.annotation.Nullable String firstName) {
    this.firstName = firstName;
    return this;
  }

  /**
   * The first name (also known as given name)
   * @return firstName
   */
  @javax.annotation.Nullable
  public String getFirstName() {
    return firstName;
  }

  public void setFirstName(@javax.annotation.Nullable String firstName) {
    this.firstName = firstName;
  }


  public FirstLastNameCasteOut lastName(@javax.annotation.Nullable String lastName) {
    this.lastName = lastName;
    return this;
  }

  /**
   * The last name (also known as family name, or surname)
   * @return lastName
   */
  @javax.annotation.Nullable
  public String getLastName() {
    return lastName;
  }

  public void setLastName(@javax.annotation.Nullable String lastName) {
    this.lastName = lastName;
  }


  public FirstLastNameCasteOut caste(@javax.annotation.Nullable String caste) {
    this.caste = caste;
    return this;
  }

  /**
   * Most likely caste
   * @return caste
   */
  @javax.annotation.Nullable
  public String getCaste() {
    return caste;
  }

  public void setCaste(@javax.annotation.Nullable String caste) {
    this.caste = caste;
  }


  public FirstLastNameCasteOut casteAlt(@javax.annotation.Nullable String casteAlt) {
    this.casteAlt = casteAlt;
    return this;
  }

  /**
   * Second best alternative : caste
   * @return casteAlt
   */
  @javax.annotation.Nullable
  public String getCasteAlt() {
    return casteAlt;
  }

  public void setCasteAlt(@javax.annotation.Nullable String casteAlt) {
    this.casteAlt = casteAlt;
  }


  public FirstLastNameCasteOut casteTop(@javax.annotation.Nullable List<String> casteTop) {
    this.casteTop = casteTop;
    return this;
  }

  public FirstLastNameCasteOut addCasteTopItem(String casteTopItem) {
    if (this.casteTop == null) {
      this.casteTop = new ArrayList<>();
    }
    this.casteTop.add(casteTopItem);
    return this;
  }

  /**
   * List caste(top 10)
   * @return casteTop
   */
  @javax.annotation.Nullable
  public List<String> getCasteTop() {
    return casteTop;
  }

  public void setCasteTop(@javax.annotation.Nullable List<String> casteTop) {
    this.casteTop = casteTop;
  }


  public FirstLastNameCasteOut score(@javax.annotation.Nullable Double score) {
    this.score = score;
    return this;
  }

  /**
   * Compatibility to NamSor_v1 Origin score value. Higher score is better, but score is not normalized. Use calibratedProbability if available. 
   * minimum: 0
   * maximum: 100
   * @return score
   */
  @javax.annotation.Nullable
  public Double getScore() {
    return score;
  }

  public void setScore(@javax.annotation.Nullable Double score) {
    this.score = score;
  }


  public FirstLastNameCasteOut probabilityCalibrated(@javax.annotation.Nullable Double probabilityCalibrated) {
    this.probabilityCalibrated = probabilityCalibrated;
    return this;
  }

  /**
   * The calibrated probability for caste to have been guessed correctly. -1 &#x3D; still calibrating. 
   * minimum: -1
   * maximum: 1
   * @return probabilityCalibrated
   */
  @javax.annotation.Nullable
  public Double getProbabilityCalibrated() {
    return probabilityCalibrated;
  }

  public void setProbabilityCalibrated(@javax.annotation.Nullable Double probabilityCalibrated) {
    this.probabilityCalibrated = probabilityCalibrated;
  }


  public FirstLastNameCasteOut probabilityAltCalibrated(@javax.annotation.Nullable Double probabilityAltCalibrated) {
    this.probabilityAltCalibrated = probabilityAltCalibrated;
    return this;
  }

  /**
   * The calibrated probability for caste OR casteAlt to have been guessed correctly. -1 &#x3D; still calibrating. 
   * minimum: -1
   * maximum: 1
   * @return probabilityAltCalibrated
   */
  @javax.annotation.Nullable
  public Double getProbabilityAltCalibrated() {
    return probabilityAltCalibrated;
  }

  public void setProbabilityAltCalibrated(@javax.annotation.Nullable Double probabilityAltCalibrated) {
    this.probabilityAltCalibrated = probabilityAltCalibrated;
  }



  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    FirstLastNameCasteOut firstLastNameCasteOut = (FirstLastNameCasteOut) o;
    return Objects.equals(this.script, firstLastNameCasteOut.script) &&
        Objects.equals(this.id, firstLastNameCasteOut.id) &&
        Objects.equals(this.explanation, firstLastNameCasteOut.explanation) &&
        Objects.equals(this.firstName, firstLastNameCasteOut.firstName) &&
        Objects.equals(this.lastName, firstLastNameCasteOut.lastName) &&
        Objects.equals(this.caste, firstLastNameCasteOut.caste) &&
        Objects.equals(this.casteAlt, firstLastNameCasteOut.casteAlt) &&
        Objects.equals(this.casteTop, firstLastNameCasteOut.casteTop) &&
        Objects.equals(this.score, firstLastNameCasteOut.score) &&
        Objects.equals(this.probabilityCalibrated, firstLastNameCasteOut.probabilityCalibrated) &&
        Objects.equals(this.probabilityAltCalibrated, firstLastNameCasteOut.probabilityAltCalibrated);
  }

  @Override
  public int hashCode() {
    return Objects.hash(script, id, explanation, firstName, lastName, caste, casteAlt, casteTop, score, probabilityCalibrated, probabilityAltCalibrated);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class FirstLastNameCasteOut {\n");
    sb.append("    script: ").append(toIndentedString(script)).append("\n");
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    explanation: ").append(toIndentedString(explanation)).append("\n");
    sb.append("    firstName: ").append(toIndentedString(firstName)).append("\n");
    sb.append("    lastName: ").append(toIndentedString(lastName)).append("\n");
    sb.append("    caste: ").append(toIndentedString(caste)).append("\n");
    sb.append("    casteAlt: ").append(toIndentedString(casteAlt)).append("\n");
    sb.append("    casteTop: ").append(toIndentedString(casteTop)).append("\n");
    sb.append("    score: ").append(toIndentedString(score)).append("\n");
    sb.append("    probabilityCalibrated: ").append(toIndentedString(probabilityCalibrated)).append("\n");
    sb.append("    probabilityAltCalibrated: ").append(toIndentedString(probabilityAltCalibrated)).append("\n");
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
    openapiFields.add("script");
    openapiFields.add("id");
    openapiFields.add("explanation");
    openapiFields.add("firstName");
    openapiFields.add("lastName");
    openapiFields.add("caste");
    openapiFields.add("casteAlt");
    openapiFields.add("casteTop");
    openapiFields.add("score");
    openapiFields.add("probabilityCalibrated");
    openapiFields.add("probabilityAltCalibrated");

    // a set of required properties/fields (JSON key names)
    openapiRequiredFields = new HashSet<String>();
  }

  /**
   * Validates the JSON Element and throws an exception if issues found
   *
   * @param jsonElement JSON Element
   * @throws IOException if the JSON Element is invalid with respect to FirstLastNameCasteOut
   */
  public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      if (jsonElement == null) {
        if (!FirstLastNameCasteOut.openapiRequiredFields.isEmpty()) { // has required fields but JSON element is null
          throw new IllegalArgumentException(String.format("The required field(s) %s in FirstLastNameCasteOut is not found in the empty JSON string", FirstLastNameCasteOut.openapiRequiredFields.toString()));
        }
      }

      Set<Map.Entry<String, JsonElement>> entries = jsonElement.getAsJsonObject().entrySet();
      // check to see if the JSON string contains additional fields
      for (Map.Entry<String, JsonElement> entry : entries) {
        if (!FirstLastNameCasteOut.openapiFields.contains(entry.getKey())) {
          throw new IllegalArgumentException(String.format("The field `%s` in the JSON string is not defined in the `FirstLastNameCasteOut` properties. JSON: %s", entry.getKey(), jsonElement.toString()));
        }
      }
        JsonObject jsonObj = jsonElement.getAsJsonObject();
      if ((jsonObj.get("script") != null && !jsonObj.get("script").isJsonNull()) && !jsonObj.get("script").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `script` to be a primitive type in the JSON string but got `%s`", jsonObj.get("script").toString()));
      }
      if ((jsonObj.get("id") != null && !jsonObj.get("id").isJsonNull()) && !jsonObj.get("id").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `id` to be a primitive type in the JSON string but got `%s`", jsonObj.get("id").toString()));
      }
      if ((jsonObj.get("explanation") != null && !jsonObj.get("explanation").isJsonNull()) && !jsonObj.get("explanation").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `explanation` to be a primitive type in the JSON string but got `%s`", jsonObj.get("explanation").toString()));
      }
      if ((jsonObj.get("firstName") != null && !jsonObj.get("firstName").isJsonNull()) && !jsonObj.get("firstName").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `firstName` to be a primitive type in the JSON string but got `%s`", jsonObj.get("firstName").toString()));
      }
      if ((jsonObj.get("lastName") != null && !jsonObj.get("lastName").isJsonNull()) && !jsonObj.get("lastName").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `lastName` to be a primitive type in the JSON string but got `%s`", jsonObj.get("lastName").toString()));
      }
      if ((jsonObj.get("caste") != null && !jsonObj.get("caste").isJsonNull()) && !jsonObj.get("caste").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `caste` to be a primitive type in the JSON string but got `%s`", jsonObj.get("caste").toString()));
      }
      if ((jsonObj.get("casteAlt") != null && !jsonObj.get("casteAlt").isJsonNull()) && !jsonObj.get("casteAlt").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `casteAlt` to be a primitive type in the JSON string but got `%s`", jsonObj.get("casteAlt").toString()));
      }
      // ensure the optional json data is an array if present
      if (jsonObj.get("casteTop") != null && !jsonObj.get("casteTop").isJsonNull() && !jsonObj.get("casteTop").isJsonArray()) {
        throw new IllegalArgumentException(String.format("Expected the field `casteTop` to be an array in the JSON string but got `%s`", jsonObj.get("casteTop").toString()));
      }
  }

  public static class CustomTypeAdapterFactory implements TypeAdapterFactory {
    @SuppressWarnings("unchecked")
    @Override
    public <T> TypeAdapter<T> create(Gson gson, TypeToken<T> type) {
       if (!FirstLastNameCasteOut.class.isAssignableFrom(type.getRawType())) {
         return null; // this class only serializes 'FirstLastNameCasteOut' and its subtypes
       }
       final TypeAdapter<JsonElement> elementAdapter = gson.getAdapter(JsonElement.class);
       final TypeAdapter<FirstLastNameCasteOut> thisAdapter
                        = gson.getDelegateAdapter(this, TypeToken.get(FirstLastNameCasteOut.class));

       return (TypeAdapter<T>) new TypeAdapter<FirstLastNameCasteOut>() {
           @Override
           public void write(JsonWriter out, FirstLastNameCasteOut value) throws IOException {
             JsonObject obj = thisAdapter.toJsonTree(value).getAsJsonObject();
             elementAdapter.write(out, obj);
           }

           @Override
           public FirstLastNameCasteOut read(JsonReader in) throws IOException {
             JsonElement jsonElement = elementAdapter.read(in);
             validateJsonElement(jsonElement);
             return thisAdapter.fromJsonTree(jsonElement);
           }

       }.nullSafe();
    }
  }

  /**
   * Create an instance of FirstLastNameCasteOut given an JSON string
   *
   * @param jsonString JSON string
   * @return An instance of FirstLastNameCasteOut
   * @throws IOException if the JSON string is invalid with respect to FirstLastNameCasteOut
   */
  public static FirstLastNameCasteOut fromJson(String jsonString) throws IOException {
    return JSON.getGson().fromJson(jsonString, FirstLastNameCasteOut.class);
  }

  /**
   * Convert an instance of FirstLastNameCasteOut to an JSON string
   *
   * @return JSON string
   */
  public String toJson() {
    return JSON.getGson().toJson(this);
  }
}

