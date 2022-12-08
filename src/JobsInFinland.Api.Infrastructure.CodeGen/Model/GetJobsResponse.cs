/*
 * Jobs in Finland
 *
 * API specification for Jobs in Finland API
 *
 * The version of the OpenAPI document: 1.0
 * Contact: lassi.patanen@gofore.com
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
using OpenAPIDateConverter = JobsInFinland.Api.Infrastructure.CodeGen.Client.OpenAPIDateConverter;

namespace JobsInFinland.Api.Infrastructure.CodeGen.Model
{
    /// <summary>
    /// Response model for data coming from Jobs in Finland API when meta&#x3D;true
    /// </summary>
    [DataContract(Name = "GetJobsResponse")]
    public partial class GetJobsResponse : IEquatable<GetJobsResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobsResponse" /> class.
        /// </summary>
        /// <param name="total">total.</param>
        /// <param name="cities">cities.</param>
        /// <param name="categories">categories.</param>
        /// <param name="records">records.</param>
        public GetJobsResponse(int total = default(int), List<MetaCities> cities = default(List<MetaCities>), List<MetaCategory> categories = default(List<MetaCategory>), List<Job> records = default(List<Job>))
        {
            this.Total = total;
            this.Cities = cities;
            this.Categories = categories;
            this.Records = records;
        }

        /// <summary>
        /// Gets or Sets Total
        /// </summary>
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total { get; set; }

        /// <summary>
        /// Gets or Sets Cities
        /// </summary>
        [DataMember(Name = "cities", EmitDefaultValue = false)]
        public List<MetaCities> Cities { get; set; }

        /// <summary>
        /// Gets or Sets Categories
        /// </summary>
        [DataMember(Name = "categories", EmitDefaultValue = false)]
        public List<MetaCategory> Categories { get; set; }

        /// <summary>
        /// Gets or Sets Records
        /// </summary>
        [DataMember(Name = "records", EmitDefaultValue = false)]
        public List<Job> Records { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetJobsResponse {\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  Cities: ").Append(Cities).Append("\n");
            sb.Append("  Categories: ").Append(Categories).Append("\n");
            sb.Append("  Records: ").Append(Records).Append("\n");
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
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as GetJobsResponse);
        }

        /// <summary>
        /// Returns true if GetJobsResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of GetJobsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetJobsResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Total == input.Total ||
                    this.Total.Equals(input.Total)
                ) && 
                (
                    this.Cities == input.Cities ||
                    this.Cities != null &&
                    input.Cities != null &&
                    this.Cities.SequenceEqual(input.Cities)
                ) && 
                (
                    this.Categories == input.Categories ||
                    this.Categories != null &&
                    input.Categories != null &&
                    this.Categories.SequenceEqual(input.Categories)
                ) && 
                (
                    this.Records == input.Records ||
                    this.Records != null &&
                    input.Records != null &&
                    this.Records.SequenceEqual(input.Records)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                hashCode = (hashCode * 59) + this.Total.GetHashCode();
                if (this.Cities != null)
                {
                    hashCode = (hashCode * 59) + this.Cities.GetHashCode();
                }
                if (this.Categories != null)
                {
                    hashCode = (hashCode * 59) + this.Categories.GetHashCode();
                }
                if (this.Records != null)
                {
                    hashCode = (hashCode * 59) + this.Records.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
