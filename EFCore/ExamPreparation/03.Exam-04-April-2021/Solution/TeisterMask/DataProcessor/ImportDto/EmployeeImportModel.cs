using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeeImportModel
    {
        [Required]
        [RegularExpression(ValidationConstants.EmployeeUsernameRegEx)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.EmployeePhoneRegEx)]
        public string Phone { get; set; }
        
        public HashSet<int> Tasks { get; set; }
    }
}
