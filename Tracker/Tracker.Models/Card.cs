using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracker.Models
{
    [Table("card")]
    public class Card
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Board is required")]
        [ForeignKey("board_id")]
        public Board Board { get; set; }
    }
}
