namespace SaverBackend.DTO
{
    public class UpdateStatisticsDto
    {
        public Guid CategoryId { get; set; }

        public int Openings { get; set; }

        public int Favorites { get; set; }
    }
}
