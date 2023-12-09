using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Api.Core.Application.Features.Commands.User.ChangePassword
{
    public class ChangePasswordCommand : IRequest<bool>
    {
        public ChangePasswordCommand(string oldPassword, string newPassword, Guid id)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
            Id = id;
        }
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
