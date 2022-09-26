using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentImportModel
    {
        [Required]
        [MinLength(ValidationConstants.DepartmentNameMinLength)]
        [MaxLength(ValidationConstants.DepartmentNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public CellImportModel[] Cells { get; set; }
    }
}
