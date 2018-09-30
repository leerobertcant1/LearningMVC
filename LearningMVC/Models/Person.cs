using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningMVC.Models
{
    public class MaxWordsAttribute:ValidationAttribute
    {     
        public MaxWordsAttribute(int maxWords) : base("{0} has too many words")
        {
            _maxwords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if(valueAsString.Split(' ').Length > _maxwords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }

        private readonly int _maxwords;
    }
  
    public class Person: IValidatableObject
    {
        [StringLength(20)]
        [Display(Name="Fname")]
        [DisplayFormat(NullDisplayText ="No name entered")]
        [MaxWords(1)]
        public string FirstName { get; set; }

        [Display(Name = "Lname")]
        [DisplayFormat(NullDisplayText = "No name entered")]
        [MaxWords(1)]
        public string LastName { get; set; }

        [Display(Name = "Mname")]
        [DisplayFormat(NullDisplayText = "No name entered")]
        [MaxWords(1)]
        public string MiddleName { get; set; }

        [Required]
        public Guid Id { get; set; }

        public int Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FirstName.Length > 10 || LastName.Length > 10|| MiddleName.Length > 10)
            {
                yield return new ValidationResult("Characters too long");
            }
        }
    }
}