﻿using BC = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44374/api/")
        };

        [Route("login")]
        public IActionResult Login()
        {
            return View("~/Views/Auth/Login.cshtml");
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("verify")]
        public IActionResult Verify()
        {
            return View();
        }

        [Route("validate")]
        public IActionResult Validate(UserVM userVM)
        {
            if (userVM.Username == null)
            {
                var jsonUserVM = JsonConvert.SerializeObject(userVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(jsonUserVM);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var resTask = client.PostAsync("users/login/", byteContent);
                resTask.Wait();
                var result = resTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    if (data != null)
                    {
                        var handler = new JwtSecurityTokenHandler();
                        var tokenS = handler.ReadJwtToken(data);
                        var user = new UserVM();
                        user.Id = tokenS.Claims.First(claim => claim.Type == "Id").Value;
                        user.Username = tokenS.Claims.First(claim => claim.Type == "Username").Value;
                        user.Email = tokenS.Claims.First(claim => claim.Type == "Email").Value;
                        user.RoleName = tokenS.Claims.First(claim => claim.Type == "RoleName").Value;
                        //var json = JsonConvert.DeserializeObject<UserVM>(tokenS.ToString());
                        //if (tokenS.Claims.First(claim => claim.Type.Equals("VerifyCode")) != null)
                        //{
                        //    user.VerifyCode = tokenS.Claims.First(claim => claim.Type == "VerifyCode").Value;
                        //}
                        //var json = JsonConvert.DeserializeObject(data).ToString();
                        //var account = JsonConvert.DeserializeObject<UserVM>(json);
                        //if (BC.Verify(userVM.Password, account.Password) && (account.RoleName == "Admin" || account.RoleName == "Sales"))
                        if (user.VerifyCode != null)
                        {
                            if (userVM.VerifyCode != user.VerifyCode)
                            {
                                return Json(new { status = true, msg = "Check your Code" });
                            }
                        }
                        else if (user.RoleName == "Admin" || user.RoleName == "Sales")
                        {
                            HttpContext.Session.SetString("id", user.Id);
                            HttpContext.Session.SetString("uname", user.Username);
                            HttpContext.Session.SetString("email", user.Email);
                            HttpContext.Session.SetString("lvl", user.RoleName);
                            if (user.RoleName == "Admin")
                            {
                                return Json(new { status = true, msg = "Login Successfully !", acc = "Admin" });
                            }
                            else
                            {
                                return Json(new { status = true, msg = "Login Successfully !", acc = "Sales" });
                            }
                        }
                        else
                        {
                            return Json(new { status = false, msg = "Invalid Username or Password!" });
                        }
                    }
                    else
                    {
                        return Json(new { status = false, msg = "Username Not Found!" });
                    }
                }
                else
                {
                    //return RedirectToAction("Login","Auth");
                    return Json(new { status = false, msg = "Something Wrong!" });
                }
            }
            else if (userVM.Username != null)
            {
                var json = JsonConvert.SerializeObject(userVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client.PostAsync("users/register/", byteContent).Result;
                if (result.IsSuccessStatusCode)
                {
                    return Json(new { status = true, code = result, msg = "Register Success! " });
                }
                else
                {
                    return Json(new { status = false, msg = "Something Wrong!" });
                }
            }
            return Redirect("/login");
        }

        [Route("verifCode")]
        public IActionResult VerifCode(UserVM userVM)
        {
            if (userVM.VerifyCode != null)
            {
                var jsonUserVM = JsonConvert.SerializeObject(userVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(jsonUserVM);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client.PostAsync("users/code/", byteContent).Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    if (data != "")
                    {
                        var json = JsonConvert.DeserializeObject(data).ToString();
                        var account = JsonConvert.DeserializeObject<UserVM>(json);
                        if (account.RoleName == "Admin" || account.RoleName == "Sales")
                        {
                            HttpContext.Session.SetString("id", account.Id);
                            HttpContext.Session.SetString("uname", account.Username);
                            HttpContext.Session.SetString("email", account.Email);
                            HttpContext.Session.SetString("lvl", account.RoleName);
                            if (account.RoleName == "Admin")
                            {
                                return Json(new { status = true, msg = "Login Successfully !", acc = "Admin" });
                            }
                            else
                            {
                                return Json(new { status = true, msg = "Login Successfully !", acc = "Sales" });
                            }
                        }
                        else
                        {
                            return Json(new { status = false, msg = "Invalid Username or Password!" });
                        }
                    }
                    else
                    {
                        return Json(new { status = false, msg = "Username Not Found!" });
                    }
                    //var data = result.Content.ReadAsStringAsync().Result;
                    //var json = JsonConvert.DeserializeObject(data).ToString();
                    //var account = JsonConvert.DeserializeObject<UserVM>(json);
                    //var dataLogin = new UserVM()
                    //{
                    //    Email = account.Email,
                    //    Password = account.Password
                    //};
                    //this.Validate(dataLogin);
                    //return Json(new { status = true, code = result, msg = "Login Success! " });
                }
                else
                {
                    return Json(new { status = false, msg = "Your Code is Wrong!" });
                }
            }
            else
            {
                return Json(new { status = false, msg = "Something Wrong!" });
            }
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            //HttpContext.Session.Remove("lvl");
            HttpContext.Session.Clear();
            return Redirect("/login");
        }

        [Route("getjwt")]
        public IActionResult GetName()
        {
            var stream = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6ImRiM2VhZmIxLTkyMWUtNDdmYS1hOGFiLTIwNDYxMzkxM2FlMCIsIlVzZXJuYW1lIjoiUmlmcXkiLCJFbWFpbCI6Im11aGFtbWFkcmlmcWkwQGdtYWlsLmNvbSIsIlJvbGVOYW1lIjoiU2FsZXMiLCJleHAiOjE1OTk1NDY0MTYsImlzcyI6IkludmVudG9yeUF1dGhlbnRpY2F0aW9uU2VydmVyIiwiYXVkIjoiSW52ZW50b3J5c2VydmljZVBvc3RtYW50Q2xpZW50In0.ziIjgvqJdH17w4HwHGzvXyZTUz41S06i0xHWGxAnY2M";
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadJwtToken(stream);
            //var cek = tokenS.Payload;
            //cek.u

            //var jsonToken = handler.ReadToken(stream);
            //var tokenS = handler.ReadToken(stream) as JwtSecurityToken;

            //var id = tokenS.Claims.First(claim => claim.Type == "Id").Value;
            //var uname = tokenS.Claims.First(claim => claim.Type == "Username").Value;
            //var mail = tokenS.Claims.First(claim => claim.Type == "Email").Value;
            //var role = tokenS.Claims.First(claim => claim.Type == "RoleName").Value;

            var user = new UserVM()
            {
                Id = tokenS.Claims.First(claim => claim.Type == "Id").Value,
                Username = tokenS.Claims.First(claim => claim.Type == "Username").Value,
                Email = tokenS.Claims.First(claim => claim.Type == "Email").Value,
                RoleName = tokenS.Claims.First(claim => claim.Type == "RoleName").Value,
            };

            var usrVm = new UserVM();
            //return Json(user);
            return Json(tokenS.Payload);
        }
    }
}
