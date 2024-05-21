using MediatR;
using Registration.Application.DTO;


namespace Registration.Application.Queries
{
    public class GetCitiesQuery : IRequest<List<CityDto>>
    {
        public int GovernateId { get; set; }

        public GetCitiesQuery(int governateId)
        {
            GovernateId = governateId;
        }
    }
}
