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
    /// APIKeyOut
    /// </summary>
    [DataContract(Name = "APIKeyOut")]
    public partial class APIKeyOut : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIKeyOut" /> class.
        /// </summary>
        /// <param name="apiKey">The user API Key..</param>
        /// <param name="userId">The user identifier..</param>
        /// <param name="admin">The API Key has admin role..</param>
        /// <param name="vetted">The API Key is vetted (assumed truthful) for machine learning..</param>
        /// <param name="learnable">The API Key is learnable (without assuming truthfulness) for machine learning. Set learnable&#x3D;false and anonymized&#x3D;true for highest privacy (ie. to forget data as it&#39;s processed)..</param>
        /// <param name="anonymized">The API Key is anonymized (using SHA-252 digest for logging). Set learnable&#x3D;false and anonymized&#x3D;true for highest privacy (ie. to forget data as it&#39;s processed)..</param>
        /// <param name="partner">The API Key has partner role..</param>
        /// <param name="striped">The API Key is associated to a valid Stripe account..</param>
        /// <param name="corporate">The API Key has role corporate (ex SWIFT payments instead of Stripe payments)..</param>
        /// <param name="disabled">The API Key is temporarily or permanently disabled..</param>
        /// <param name="explainable">The API Key supports the AI explainability option (may require a specific license)..</param>
        /// <param name="ipAddress">ipAddress.</param>
        /// <param name="communityEngageOption">communityEngageOption.</param>
        public APIKeyOut(string apiKey = default(string), string userId = default(string), bool admin = default(bool), bool vetted = default(bool), bool learnable = default(bool), bool anonymized = default(bool), bool partner = default(bool), bool striped = default(bool), bool corporate = default(bool), bool disabled = default(bool), bool explainable = default(bool), string ipAddress = default(string), CommunityEngageOptionOut communityEngageOption = default(CommunityEngageOptionOut))
        {
            this.ApiKey = apiKey;
            this.UserId = userId;
            this.Admin = admin;
            this.Vetted = vetted;
            this.Learnable = learnable;
            this.Anonymized = anonymized;
            this.Partner = partner;
            this.Striped = striped;
            this.Corporate = corporate;
            this.Disabled = disabled;
            this.Explainable = explainable;
            this.IpAddress = ipAddress;
            this.CommunityEngageOption = communityEngageOption;
        }

        /// <summary>
        /// The user API Key.
        /// </summary>
        /// <value>The user API Key.</value>
        [DataMember(Name = "apiKey", EmitDefaultValue = false)]
        public string ApiKey { get; set; }

        /// <summary>
        /// The user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public string UserId { get; set; }

        /// <summary>
        /// The API Key has admin role.
        /// </summary>
        /// <value>The API Key has admin role.</value>
        [DataMember(Name = "admin", EmitDefaultValue = true)]
        public bool Admin { get; set; }

        /// <summary>
        /// The API Key is vetted (assumed truthful) for machine learning.
        /// </summary>
        /// <value>The API Key is vetted (assumed truthful) for machine learning.</value>
        [DataMember(Name = "vetted", EmitDefaultValue = true)]
        public bool Vetted { get; set; }

        /// <summary>
        /// The API Key is learnable (without assuming truthfulness) for machine learning. Set learnable&#x3D;false and anonymized&#x3D;true for highest privacy (ie. to forget data as it&#39;s processed).
        /// </summary>
        /// <value>The API Key is learnable (without assuming truthfulness) for machine learning. Set learnable&#x3D;false and anonymized&#x3D;true for highest privacy (ie. to forget data as it&#39;s processed).</value>
        [DataMember(Name = "learnable", EmitDefaultValue = true)]
        public bool Learnable { get; set; }

        /// <summary>
        /// The API Key is anonymized (using SHA-252 digest for logging). Set learnable&#x3D;false and anonymized&#x3D;true for highest privacy (ie. to forget data as it&#39;s processed).
        /// </summary>
        /// <value>The API Key is anonymized (using SHA-252 digest for logging). Set learnable&#x3D;false and anonymized&#x3D;true for highest privacy (ie. to forget data as it&#39;s processed).</value>
        [DataMember(Name = "anonymized", EmitDefaultValue = true)]
        public bool Anonymized { get; set; }

        /// <summary>
        /// The API Key has partner role.
        /// </summary>
        /// <value>The API Key has partner role.</value>
        [DataMember(Name = "partner", EmitDefaultValue = true)]
        public bool Partner { get; set; }

        /// <summary>
        /// The API Key is associated to a valid Stripe account.
        /// </summary>
        /// <value>The API Key is associated to a valid Stripe account.</value>
        [DataMember(Name = "striped", EmitDefaultValue = true)]
        public bool Striped { get; set; }

        /// <summary>
        /// The API Key has role corporate (ex SWIFT payments instead of Stripe payments).
        /// </summary>
        /// <value>The API Key has role corporate (ex SWIFT payments instead of Stripe payments).</value>
        [DataMember(Name = "corporate", EmitDefaultValue = true)]
        public bool Corporate { get; set; }

        /// <summary>
        /// The API Key is temporarily or permanently disabled.
        /// </summary>
        /// <value>The API Key is temporarily or permanently disabled.</value>
        [DataMember(Name = "disabled", EmitDefaultValue = true)]
        public bool Disabled { get; set; }

        /// <summary>
        /// The API Key supports the AI explainability option (may require a specific license).
        /// </summary>
        /// <value>The API Key supports the AI explainability option (may require a specific license).</value>
        [DataMember(Name = "explainable", EmitDefaultValue = true)]
        public bool Explainable { get; set; }

        /// <summary>
        /// Gets or Sets IpAddress
        /// </summary>
        [DataMember(Name = "ipAddress", EmitDefaultValue = false)]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or Sets CommunityEngageOption
        /// </summary>
        [DataMember(Name = "communityEngageOption", EmitDefaultValue = false)]
        public CommunityEngageOptionOut CommunityEngageOption { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class APIKeyOut {\n");
            sb.Append("  ApiKey: ").Append(ApiKey).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  Admin: ").Append(Admin).Append("\n");
            sb.Append("  Vetted: ").Append(Vetted).Append("\n");
            sb.Append("  Learnable: ").Append(Learnable).Append("\n");
            sb.Append("  Anonymized: ").Append(Anonymized).Append("\n");
            sb.Append("  Partner: ").Append(Partner).Append("\n");
            sb.Append("  Striped: ").Append(Striped).Append("\n");
            sb.Append("  Corporate: ").Append(Corporate).Append("\n");
            sb.Append("  Disabled: ").Append(Disabled).Append("\n");
            sb.Append("  Explainable: ").Append(Explainable).Append("\n");
            sb.Append("  IpAddress: ").Append(IpAddress).Append("\n");
            sb.Append("  CommunityEngageOption: ").Append(CommunityEngageOption).Append("\n");
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
