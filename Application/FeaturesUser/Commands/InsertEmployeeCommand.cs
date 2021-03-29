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
    public class InsertEmployeeCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int SocialNumber { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int CityID { get; set; }

        public class InsertEmployeeCommandHandler : IRequestHandler<InsertEmployeeCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public InsertEmployeeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(InsertEmployeeCommand request, CancellationToken cancellationToken)
            {
                City city = new City();
                Employee emp = new Employee();
                emp.SocialNumber = request.SocialNumber;
                emp.FirstName = request.FirstName;
                emp.LastName = request.LastName;
                emp.ModifiedOn = DateTime.Now;
                emp.CreatedOn = DateTime.Now;
                emp.BirthDate = request.BirthDate;
                emp.Password = request.Password;
                emp.Email = request.Email;
                emp.Phone = request.Phone;
                emp.EmploymentDate = request.EmploymentDate;
                emp.CityID = request.CityID;
                _context.Users.Add(emp);
                await _context.SaveChangesAsync();
                return emp.Id;
            }
        }
    }
}
