using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Common.Models.RequestModels.User.Login
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {

        public LoginUserCommand(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }

        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
