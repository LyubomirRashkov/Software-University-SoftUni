using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorImportModel
    {
        [Required]
        [MinLength(ValidationConstants.AuthorFirstNameMinLength)]
        [MaxLength(ValidationConstants.AuthorFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ValidationConstants.AuthorLastNameMinLength)]
        [MaxLength(ValidationConstants.AuthorLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.AuthorPhoneRegEx)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public HashSet<AuthorBookImportModel> Books { get; set; }
    }
}
