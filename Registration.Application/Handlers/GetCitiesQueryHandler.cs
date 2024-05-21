using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registration.Application.DTO;
using Registration.Application.Queries;
using Registration.Domain.Entities;
using Registration.Persistance;

namespace Registration.Application.Handlers
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, List<CityDto>>
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;
        public GetCitiesQueryHandler(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CityDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await _context.Citys.Where(c => request.GovernateId == c.GovernateId).ToListAsync();
            return _mapper.Map<List<CityDto>>(cities);
        }
    }
}
