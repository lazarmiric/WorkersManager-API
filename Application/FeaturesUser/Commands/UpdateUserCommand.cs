using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FeaturesUser.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CityID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {
         

            private readonly IApplicationDbContext _context;
            public UpdateUserCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = _context.Users.Include(c=>c.City).Where(u => u.Id == request.Id).FirstOrDefault();
                //user.City = new City();
                if(user == null) { return default; }
                else
                {
                    if (!String.IsNullOrEmpty(request.FirstName)) user.FirstName = request.FirstName;
                    if (!String.IsNullOrEmpty(request.LastName)) user.LastName = request.LastName;
                    if (request.CityID!=0) user.CityID = request.CityID;
                    if (!String.IsNullOrEmpty(request.Email)) user.Email = request.Email;
                    if (!String.IsNullOrEmpty(request.Phone)) user.Phone = request.Phone;
                    user.ModifiedOn = DateTime.Now;
                    await _context.SaveChangesAsync();
                    return user.Id;
                }
            }
        }
    }
}
