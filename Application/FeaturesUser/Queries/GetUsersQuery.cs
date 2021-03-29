using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FeaturesUser.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
        {
            private readonly IApplicationDbContext _context;
            public GetUsersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                var users = await _context.Users.Include(u => u.City).ToListAsync();
                //var userList = await _context.Users.S
                if(users is null)
                {
                    return null;
                }
                return users.AsReadOnly();
            }
        }
    }
}
