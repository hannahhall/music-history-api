using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHistoryApi.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [StringLength(55)]
        public string Name { get; set; }

        public ICollection<Song> Songs;
    }
}