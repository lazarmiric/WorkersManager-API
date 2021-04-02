using Application.Interfaces;
using Domain.DataTransferObject;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.FeaturesUser.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<UserDTO>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CityName { get; set; }
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDTO>>
        {
            private readonly IApplicationDbContext _context;
            public GetUsersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                    var query = from x in _context.Users.Include(c => c.City)
                            where (x.FirstName == request.FirstName || request.FirstName == "")
                            && (x.LastName == request.LastName || request.LastName == "")
                            && (x.City.Name == request.CityName || request.CityName == "" ) select x;

                return query.AsEnumerable().Select(users => new UserDTO { FirstName = users.FirstName, LastName = users.LastName,Id = users.Id,CityName = users.City.Name});
            }
        }
    }
}
