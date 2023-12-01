using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.RequestModels.User
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public CreateUserCommand(string firstName, string lastName, string emailAddress, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            UserName = userName;
            Password = password;
        }

        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
