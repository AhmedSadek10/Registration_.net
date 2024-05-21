using MediatR;
using Registration.Application.DTO;


namespace Registration.Application.Queries
{
    public class GetGovernatesQuery : IRequest<List<GovernateDto>>
    {
    }
}
