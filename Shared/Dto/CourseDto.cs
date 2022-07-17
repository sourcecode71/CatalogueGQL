namespace Catalogue.Shared.Dto
{
    public class CourseDto
    {
        public int? Id { get; set; }
        public string? Code { get; set; }

        public string? Title { get; set; }
        public double CreditHours { get; set; }

        public int SchoolId { get; set; }
    }
}
