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
    /// Clustering
    /// </summary>
    [DataContract(Name = "Clustering")]
    public partial class Clustering : IEquatable<Clustering>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Clustering" /> class.
        /// </summary>
        /// <param name="categories">categories.</param>
        /// <param name="tags">tags.</param>
        /// <param name="position">position.</param>
        public Clustering(List<Category> categories = default(List<Category>), List<Tag> tags = default(List<Tag>), Position position = default(Position))
        {
            this.Categories = categories;
            this.Tags = tags;
            this.Position = position;
        }

        /// <summary>
        /// Gets or Sets Categories
        /// </summary>
        [DataMember(Name = "categories", EmitDefaultValue = false)]
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [DataMember(Name = "position", EmitDefaultValue = false)]
        public Position Position { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Clustering {\n");
            sb.Append("  Categories: ").Append(Categories).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
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
            return this.Equals(input as Clustering);
        }

        /// <summary>
        /// Returns true if Clustering instances are equal
        /// </summary>
        /// <param name="input">Instance of Clustering to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Clustering input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Categories == input.Categories ||
                    this.Categories != null &&
                    input.Categories != null &&
                    this.Categories.SequenceEqual(input.Categories)
                ) && 
                (
                    this.Tags == input.Tags ||
                    this.Tags != null &&
                    input.Tags != null &&
                    this.Tags.SequenceEqual(input.Tags)
                ) && 
                (
                    this.Position == input.Position ||
                    (this.Position != null &&
                    this.Position.Equals(input.Position))
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
                if (this.Categories != null)
                {
                    hashCode = (hashCode * 59) + this.Categories.GetHashCode();
                }
                if (this.Tags != null)
                {
                    hashCode = (hashCode * 59) + this.Tags.GetHashCode();
                }
                if (this.Position != null)
                {
                    hashCode = (hashCode * 59) + this.Position.GetHashCode();
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
