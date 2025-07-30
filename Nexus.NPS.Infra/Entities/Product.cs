using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.NPS.Infra.Entities
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_name")]
        public required string ProductName{ get; set; }
    }
}