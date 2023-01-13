using MyApplicationApi.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.ValidationAttributes
{
    public class BookTitleDescriptionValidationAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var book = (BookCreationDTO)validationContext.ObjectInstance;
            if(book.Title == book.Description)
            {
                //return new ValidationResult("The Title and Description of the book should be different", 
                //    new[] { nameof(BookCreationDTO) });

                return new ValidationResult(ErrorMessage,
                    new[] { nameof(BookCreationDTO) });
            }

            return ValidationResult.Success;
        }
    }
}
