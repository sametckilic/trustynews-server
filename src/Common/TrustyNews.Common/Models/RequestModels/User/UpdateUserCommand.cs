using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.RequestModels.User
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public UpdateUserCommand(Guid id, string firstName, string lastName, string emailAddress, string password, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Password = password;
            PhoneNumber = phoneNumber;
        }
        public Guid Id { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string EmailAddress {  get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}
