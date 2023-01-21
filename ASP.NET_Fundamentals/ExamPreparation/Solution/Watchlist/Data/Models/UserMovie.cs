using System.ComponentModel.DataAnnotations;

namespace Watchlist.Data.Models
{
    public class UserMovie
    {
        [Required]
        public string UserId { get; set; } = null!;

        public virtual User User { get; set; } = null!;

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!; 
    }
}
