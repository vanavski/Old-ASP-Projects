﻿using Microsoft.IdentityModel.Tokens;
using NewVision.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NewVision.Web
{
    public class TokenService
    {
        private readonly UserDomainService _userService;

        public TokenService(UserDomainService userService)
        {
            _userService = userService;
        }

        public string GetToken(string username)
        {
            var identity = GetIdentity(username);

            var key = AuthOptions.GetSymmetricSecurityKey();
            var now = DateTime.Now;
            var jwt = new JwtSecurityToken(
                AuthOptions.Issuer,
                AuthOptions.Audience,
                identity.Claims,
                now,
                now.AddMinutes(AuthOptions.Lifetime),
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return token;
        }

        private ClaimsIdentity GetIdentity(string login)
        {
            var user = _userService.Get(login);
            var claims = new List<Claim>
            {
                new Claim("UserLogin", user.Login),
                new Claim("Role", user.Role.ToString())
            };

            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
