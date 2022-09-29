using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserInputModel
    {
        [Required]
        [RegularExpression(GlobalConstants.UserFullNameRegEx)]
        public string FullName { get; set; }

        [Required]
        [MinLength(GlobalConstants.UserUsernameMinLength)]
        [MaxLength(GlobalConstants.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(GlobalConstants.UserAgeMinValue, GlobalConstants.UserAgeMaxValue)]
        public int Age { get; set; }

        public IEnumerable<CardInputModel> Cards { get; set; }
    }
}
