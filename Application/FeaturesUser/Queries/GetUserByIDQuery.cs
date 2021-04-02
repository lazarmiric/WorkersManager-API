using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FeaturesUser.Queries
{
    public class GetUserByIDQuery : IRequest<User>
    {
        public int Id { get; set; }
        public class GetUserByIDQueryHandler : IRequestHandler<GetUserByIDQuery, User>
        {
            
            private readonly IApplicationDbContext _context;
            public GetUserByIDQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
           
            public async Task<User> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
            {
                var user = _context.Users.Where(c => c.Id == request.Id).FirstOrDefault();
                if (user == null) return null;
                return user;
            }
        }
    }
}
