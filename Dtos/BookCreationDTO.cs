using MyApplicationApi.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Dtos
{
    [BookTitleDescriptionValidationAttribute(ErrorMessage = "Title and Description should not be same")]
    public class BookCreationDTO //: IValidatableObject
    {       
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public int AuthorId { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if(Title == Description)
        //    {
        //        yield return new ValidationResult
        //            ("The Provided description should be different from the title of the book",
        //            new[] { "BookCreationDTO" });

        //    }

        //    if(Price <= 0)
        //    {
        //        yield return new ValidationResult
        //            ("The price cannot be negative of zero", new[] { "BookCreationDTO" });
        //    }
        //}
    }
}
