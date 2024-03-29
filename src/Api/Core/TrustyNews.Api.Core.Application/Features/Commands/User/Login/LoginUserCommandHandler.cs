﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Exceptions;
using TrustyNews.Common.Infrastructure;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Commands.User.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository userRepository;
        private readonly IUserPhotoRepository userPhotoRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration, IUserPhotoRepository userPhotoRepository)
        {
            this.userPhotoRepository = userPhotoRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

            if (dbUser == null)
                throw new DatabaseValidationException("User not found!");

            var pass = PasswordEncrypter.Encrypt(request.Password);

            if (dbUser.Password != pass)
                throw new DatabaseValidationException("Password is wrong!");

            // TODO email dogrulama yoksa girisi engelle!!!

            var dbUserPhoto = userPhotoRepository.AsQueryable().Where(i => i.CreatedById == dbUser.Id).FirstOrDefault();
            
            var result = mapper.Map<LoginUserViewModel>(dbUser);

            var claims = new Claim[]
            {
                new Claim("id", dbUser.Id.ToString()),
                new Claim("emailAddress" , dbUser.EmailAddress),
                new Claim("userName", dbUser.UserName),
                new Claim("firstName", dbUser.FirstName),
                new Claim("surName", dbUser.LastName),
                new Claim("photoBase" , dbUserPhoto.PhotoBase)
            };

            result.Token = GenerateToken(claims);

            return result;
        }
        private string GenerateToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT_SECRET"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(10);

            var token = new JwtSecurityToken(claims: claims,
                                             expires: expiry,
                                             signingCredentials: creds,
                                             notBefore: DateTime.Now);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
