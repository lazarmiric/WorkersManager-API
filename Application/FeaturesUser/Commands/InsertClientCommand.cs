using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FeaturesUser.Commands
{
    public class InsertClientCommand : IRequest<int>
    {
        public string FirstName { get; set; }        
        public string LastName { get; set; }        
        public DateTime BirthDate { get; set; }        
        public string Password { get; set; }        
        public string Email { get; set; }        
        public string Phone { get; set; }
        public string Adress { get; set;}
        public int CityID { get; set; }

        public class InsertClientCommandHandler : IRequestHandler<InsertClientCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public InsertClientCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(InsertClientCommand request, CancellationToken cancellationToken)
            {
                var client = new Client();
                client.Adress = request.Adress;
                client.FirstName = request.FirstName;
                client.LastName = request.LastName;
                client.ModifiedOn = DateTime.Now;
                client.CreatedOn = DateTime.Now;
                client.BirthDate = request.BirthDate;
                client.Password = request.Password;
                client.Email = request.Email;
                client.Phone = request.Phone;
                client.CityID = request.CityID;
                _context.Users.Add(client);
                await _context.SaveChangesAsync();
                return client.Id;
            }
        }
    }
}
