using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracker.Models
{
    [Table("board")]
    public class Board
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Column("title")]
        public string Title { get; set; }

        public IEnumerable<Card> Cards { get; set; }
    }
}
