
namespace Registration.Application.DTO
{
    public class GovernateDto
    {
        //GovernateId will be needed because the frontend will send it to GetCitiesQuery
        public int Id { get; set; }
        public string Governate { get; set; }
    }
}
