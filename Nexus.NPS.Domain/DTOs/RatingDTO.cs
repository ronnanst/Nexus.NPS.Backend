namespace Nexus.NPS.Domain.DTOs
{
    public class RatingDTO
    {
        public required int UserId { get; set; }
        public required int ProductId { get; set; }
        public required int Score { get; set; }
    }
}