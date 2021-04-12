using Application.Interfaces;
using Domain.DataTransferObject;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FeaturesUser.Queries
{
    public class GetUserByIDQuery : IRequest<UserDTO>
    {
        public int Id { get; set; }
        public class GetUserByIDQueryHandler : IRequestHandler<GetUserByIDQuery, UserDTO>
        {
            
            private readonly IApplicationDbContext _context;
            public GetUserByIDQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
           
            public async Task<UserDTO> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
            {            
                var query = from x in _context.Users.Include(c => c.City).Where(u => u.Id == request.Id) select x;
                return query.AsEnumerable().Select(users => new UserDTO { FirstName = users.FirstName, LastName = users.LastName, Id = users.Id, CityName = users.City.Name, UserRole = (users is Client ? "Client" : "Employee") }).FirstOrDefault();
            }
        }
    }
}
