using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registration.Application.Commands;
using Registration.Application.DTO;
using Registration.Domain.Entities;
using Registration.Persistance;

namespace Registration.Application.Handlers
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserCreateCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);

            foreach (var address in request.Addresses)
            {
                var UserAddress = _mapper.Map<Address>(address);
                UserAddress.UserId = user.Id;
                await _context.addresses.AddAsync(UserAddress);

                var UserCount = await _context.GovernateCounts.FirstOrDefaultAsync(x => x.Governate == address.Governate);
                if (UserCount == null)
                {
                    await _context.GovernateCounts.AddAsync(new GovernateCount { Governate = address.Governate, UserCount = 1 });
                }
                else
                {
                    UserCount.UserCount++;
                }
                await _context.SaveChangesAsync(cancellationToken);
            }
            
        }
    }
}
