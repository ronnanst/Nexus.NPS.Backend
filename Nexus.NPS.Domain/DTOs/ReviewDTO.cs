namespace Nexus.NPS.Domain.DTOs
{
    public class ReviewDTO
    {
        public int ProductId { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
        public int UserId { get; set; }
    }
}