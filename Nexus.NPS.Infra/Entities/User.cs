using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.NPS.Infra.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]
        public required string UserName { get; set; }
        [Column("password_hash")]
        public required string PasswordHash { get; set; }
    }
}