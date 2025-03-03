/*
 * NamSor API v2
 *
 * NamSor API v2 : enpoints to process personal names (gender, cultural origin or ethnicity) in all alphabets or languages. By default, enpoints use 1 unit per name (ex. Gender), but Ethnicity classification uses 10 to 20 units per name depending on taxonomy. Use GET methods for small tests, but prefer POST methods for higher throughput (batch processing of up to 100 names at a time). Need something you can't find here? We have many more features coming soon. Let us know, we'll do our best to add it! 
 *
 * The version of the OpenAPI document: 2.0.29
 * Contact: contact@namsor.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = App.Namsor.Client.OpenAPIDateConverter;

namespace App.Namsor.Model
{
    /// <summary>
    /// FirstLastNameGeoSubdivisionIn
    /// </summary>
    [DataContract(Name = "FirstLastNameGeoSubdivisionIn")]
    public partial class FirstLastNameGeoSubdivisionIn : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FirstLastNameGeoSubdivisionIn" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="firstName">firstName.</param>
        /// <param name="lastName">lastName.</param>
        /// <param name="countryIso2">countryIso2.</param>
        /// <param name="subdivisionIso">subdivisionIso.</param>
        public FirstLastNameGeoSubdivisionIn(string id = default(string), string firstName = default(string), string lastName = default(string), string countryIso2 = default(string), string subdivisionIso = default(string))
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CountryIso2 = countryIso2;
            this.SubdivisionIso = subdivisionIso;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets CountryIso2
        /// </summary>
        [DataMember(Name = "countryIso2", EmitDefaultValue = false)]
        public string CountryIso2 { get; set; }

        /// <summary>
        /// Gets or Sets SubdivisionIso
        /// </summary>
        [DataMember(Name = "subdivisionIso", EmitDefaultValue = false)]
        public string SubdivisionIso { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FirstLastNameGeoSubdivisionIn {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  CountryIso2: ").Append(CountryIso2).Append("\n");
            sb.Append("  SubdivisionIso: ").Append(SubdivisionIso).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
