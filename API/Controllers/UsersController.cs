﻿using Bcrypt = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly UserManager<User> _userManager;
        public UsersController(MyContext myContext,UserManager<User> userManager)
        {
            _context = myContext;
            _userManager = userManager;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<UserVM>> GetAll()
        {
            List<UserVM> list = new List<UserVM>();
            var user = new UserVM();
            var getData = await _context.UserRole.Include("User").Include("Role").ToListAsync();
            if (getData.Count == 0)
            {
                return null;
            }
            foreach (var item in getData)
            {
                user.Id = item.User.Id;
                user.Username = item.User.UserName;
                user.Email = item.User.Email;
                user.Password = item.User.PasswordHash;
                user.Phone = item.User.PhoneNumber;
                user.RoleName = item.Role.Name; 
                list.Add(user);
            }
            return list;
        }

        [HttpGet("{id}")]
        public UserVM GetID(string id)
        {

            var getData = _context.UserRole.Include("User").Include("Role").SingleOrDefault(x => x.UserId == id);
            if (getData == null || getData.Role == null || getData.User == null)
            {
                return null;
            }
            var user = new UserVM()
            {
                Id = getData.User.Id,
                Username = getData.User.UserName,
                Email = getData.User.Email,
                Password = getData.User.PasswordHash,
                Phone = getData.User.PhoneNumber,
                RoleID = getData.Role.Id,
                RoleName = getData.Role.Name
            };
            return user;
        }

        [HttpPost]
        public IActionResult Create(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new User 
                {
                    UserName = userVM.Username,
                    Email = userVM.Email,
                    PasswordHash = Bcrypt.HashPassword(userVM.Password),
                    PhoneNumber = userVM.Phone,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                };
                _context.Users.Add(user);
                var uRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = "2"
                };
                _context.UserRole.Add(uRole);
                _context.SaveChanges();
                return Ok("Successfully Created");
            }
            return BadRequest("Not Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var getData = _context.UserRole.Include("Role").Include("User").SingleOrDefault(x => x.UserId == id);
                //var getId = _context.Users.SingleOrDefault(x => x.Id == id);
                getData.User.UserName = userVM.Username;
                getData.User.Email = userVM.Email;
                getData.User.PhoneNumber = userVM.Phone;
                if (!Bcrypt.Verify(userVM.Password, getData.User.PasswordHash))
                {
                    getData.User.PasswordHash = Bcrypt.HashPassword(userVM.Password);
                }
                getData.RoleId = userVM.RoleID;

                _context.UserRole.Update(getData);
                _context.SaveChanges();
                return Ok("Successfully Updated");
            }
            return BadRequest("Not Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var getId = _context.Users.Find(id);
            _context.Users.Remove(getId);
            _context.SaveChanges();
            return Ok("Successfully Delete");
        }


        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                this.Create(userVM);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        //[HttpGet("{}")]
        [Route("Login")]
        public IActionResult Login(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var getUserRole = _context.UserRole.Include("User").Include("Role").SingleOrDefault(x => x.User.Email == userVM.Email);
                if (getUserRole == null)
                {
                    return NotFound();
                }
                else if (userVM.Password == null || userVM.Password.Equals(""))
                {
                    return BadRequest(new { msg = "Password must filled" });
                }
                else if (!Bcrypt.Verify(userVM.Password, getUserRole.User.PasswordHash))
                {
                    return BadRequest(new { msg = "Password is Wrong" });
                }
                else
                {
                    //var user = new UserVM();
                    //user.Id = getUserRole.User.Id;
                    //user.Username = getUserRole.User.UserName;
                    //user.Email = getUserRole.User.Email;
                    //user.Password = getUserRole.User.PasswordHash;
                    //user.Phone = getUserRole.User.PhoneNumber;
                    //user.RoleName = getUserRole.Role.Name;
                    //return StatusCode(200, user);
                    return StatusCode(200, new { 
                        Id = getUserRole.User.Id,
                        Username = getUserRole.User.UserName,
                        Email = getUserRole.User.Email,
                        RoleName = getUserRole.Role.Name
                    });
                }
            }
            return BadRequest(500);
        }
    }
}