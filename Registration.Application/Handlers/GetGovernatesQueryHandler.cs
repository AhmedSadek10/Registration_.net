using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registration.Application.DTO;
using Registration.Application.Queries;
using Registration.Persistance;

namespace Registration.Application.Handlers
{
    public class GetGovernatesQueryHandler : IRequestHandler<GetGovernatesQuery, List<GovernateDto>>
    {
        protected readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetGovernatesQueryHandler(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GovernateDto>> Handle(GetGovernatesQuery request, CancellationToken cancellationToken)
        {
            var Governates = await _context.governates.ToListAsync();
            return _mapper.Map<List<GovernateDto>>(Governates);
        }
        // public async Task<List<GovernateEntity>> Handle(GetGovernatesQuery request, CancellationToken cancellationToken)
        //{
        //  return await _context.governates.ToListAsync();
        //}
    }
}
