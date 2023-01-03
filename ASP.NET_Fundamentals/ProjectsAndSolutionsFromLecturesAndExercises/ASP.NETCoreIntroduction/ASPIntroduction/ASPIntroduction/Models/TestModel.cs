
using System.ComponentModel.DataAnnotations;

namespace ASPIntroduction.Models
{
    public class TestModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ooops")]
        public string Product { get; set; }
    }
}
