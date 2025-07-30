using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.NPS.Infra.Entities
{
    [Table("rating")]
    public class Rating
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public required int UserId { get; set; }
        [Column("product_id")]
        public required int ProductId { get; set; }
        [Column("score")]
        public required int Score { get; set; }
        [Column("comment")]
        public string? Comment { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}