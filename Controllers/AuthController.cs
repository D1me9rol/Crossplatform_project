﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yudin_back.Models;

namespace Yudin_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController
    {
        public struct LoginData
        {
            public string login { get; set; }
            public string password { get; set; }
        }
        [HttpPost]
        public object GetToken([FromBody] LoginData ld)
        {
            var user = SharedData.Users.FirstOrDefault(u => u.Login == ld.login && u.Password == ld.password);
            if (user == null)
            {
                //Response.StatusCode = 401;
                return new { message = "wrong login/password, try again" };
            }
            return AuthOptions.GenerateToken(user.IsAdmin);
        }
        [HttpGet("users")]
        //[Authorize(Roles = "admin")]
        public List<User> GetUsers()
        {
            return SharedData.Users;
        }
        [HttpGet("token")]
        public object GetToken()
        {
            return AuthOptions.GenerateToken();
        }
        [HttpGet("token/secret")]
        [Authorize(Roles = "admin")]
        public object GetAdminToken()
        {
            return AuthOptions.GenerateToken(true);
        }
    }
}