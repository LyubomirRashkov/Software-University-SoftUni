using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
    public class Cast
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CastFullNameMaxLength)]
        public string FullName { get; set; }

        public bool IsMainCharacter { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CastPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public int PlayId { get; set; }

        public virtual Play Play { get; set; }
    }
}
