using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VerbsIntroduction
{
    public class Location
    {
        [Required]
        [FromForm(Name = "city")]
        public string City { get; set; } = null!; 
    }
}
