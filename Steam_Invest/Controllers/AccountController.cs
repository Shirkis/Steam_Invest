using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Steam_Invest.BLL.DTO.BindingModel;
using Steam_Invest.BLL.DTO.Models;
using Steam_Invest.DAL.Entities;
using Steam_Invest.DAL.Interfaces;
using Steam_Invest.PRL.JWT;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Steam_Invest.PRL.Controllers
{
    //public class AccountController : Controller
    //{
    //    IUnitOfWork _uow { get; set; }
    //    private readonly UserManager<AspNetUser> _userManager;
    //    private readonly RoleManager<IdentityRole> _roleManager;
    //    private IMapper _mapper;
    //    public AccountController(IUnitOfWork uow, UserManager<AspNetUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
    //    {
    //        _uow = uow;
    //        _userManager = userManager;
    //        _roleManager = roleManager;
    //        _mapper = mapper;
    //    }

    //    /// <summary>
    //    /// Return jwt-token
    //    /// </summary>
    //    /// <param name="model"></param>
    //    /// <returns></returns>
    //    [HttpPost("token")]
    //    [ProducesResponseType(typeof(TokenResponse), 200)]
    //    public async Task<IActionResult> Token([FromBody] LoginViewModel model)
    //    {
    //        try
    //        {
    //            if (!ModelState.IsValid)
    //                return BadRequest(ModelState);
    //            var user = await _userManager.FindByNameAsync(model.UserName);
    //            if (user != null)
    //            {
    //                var ok = await _userManager.CheckPasswordAsync(user, model.Password);
    //                if (ok)
    //                {
    //                    // проверяем, подтвержден ли email
    //                    //if (!await _userManager.IsEmailConfirmedAsync(user))
    //                    //{
    //                    //    ModelState.AddModelError("Email", "Вы не подтвердили свой email");
    //                    //    return BadRequest(ModelState);
    //                    //}
    //                    var userClaims = await _userManager.GetClaimsAsync(user);
    //                    var roles = await _userManager.GetRolesAsync(user);
    //                    //var roles = await _uow.AspNetUserRoles.Query()
    //                    //    .Include(s => s.Role)
    //                    //    .Where(s => s.UserId == user.Id)
    //                    //    .Select(s => s.Role.Name)
    //                    //    .ToListAsync();
    //                    var claims = new List<Claim>()
    //                    {
    //                        new Claim(ClaimsIdentity.DefaultNameClaimType, model.UserName)
    //                        //new Claim(ClaimsIdentity.DefaultRoleClaimType, roles.FirstOrDefault())
    //                    };

    //                    ClaimsIdentity claimsIdentity =
    //                         new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
    //                            ClaimsIdentity.DefaultRoleClaimType);
    //                    var now = DateTime.UtcNow;
    //                    // создаем JWT-токен
    //                    var jwt = new JwtSecurityToken(
    //                        issuer: AuthTokenOptions.ISSUER,
    //                        notBefore: now,
    //                        claims: claimsIdentity.Claims,
    //                        expires: now.Add(TimeSpan.FromMinutes(AuthTokenOptions.LIFETIME)),
    //                        signingCredentials: new SigningCredentials(AuthTokenOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    //                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

    //                    var response = new TokenResponse
    //                    {
    //                        Access_token = encodedJwt,
    //                        Username = claimsIdentity.Name,
    //                        PersonInfoId = user.PersonInfoId,
    //                        Roles = roles,
    //                        Start = now,
    //                        Finish = now.Add(TimeSpan.FromMinutes(AuthTokenOptions.LIFETIME))
    //                    };
    //                    return Ok(response);
    //                }
    //                ModelState.AddModelError("Password", "Wrong password");
    //                return BadRequest(ModelState);
    //            }

    //            ModelState.AddModelError("UserName", "User with such UserName doesn't exist");
    //            return BadRequest(ModelState);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }

    //    /// <summary>
    //    /// Register
    //    /// </summary>
    //    /// <param name="model"></param>
    //    /// <returns></returns>
    //    [HttpPost("register")]
    //    public async Task<ActionResult> Register([FromBody] RegisterBindingModel model)
    //    {
    //        if (!ModelState.IsValid)
    //            return BadRequest(ModelState);
    //        try
    //        {
    //            var emailcheck = await _uow.AspNetUsers.Query()
    //                .Where(s => s.Email == model.Email)
    //                .FirstOrDefaultAsync();
    //            if (emailcheck != null)
    //            {
    //                ModelState.AddModelError("Email", "Данный email уже зарегистрирован");
    //                return BadRequest(ModelState);
    //            }
    //            var user = new AspNetUser() { UserName = model.Email, Email = model.Email, EmailConfirmed = true };
    //            var result = await _userManager.CreateAsync(user, model.Password);
    //            if (result.Succeeded)
    //            {
    //                var person = _mapper.Map<PersonInfo>(model);
    //                person.AspNetUserId = user.Id;
    //                _uow.PersonInfo.Add(person);
    //                await _uow.SaveChangesAsync();
    //                user.PersonInfoId = person.PersonInfoId;
    //                _uow.AspNetUsers.Update(user);
    //                await _uow.SaveChangesAsync();
    //                return Ok();
    //            }
    //            else
    //            {
    //                return BadRequest(ModelState);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }


    //    [HttpPost("addrole")]
    //    public async Task<ActionResult> AddRole(string username, string role)
    //    {
    //        try
    //        {
    //            //var test = await _roleManager.CreateAsync(new IdentityRole("Admin"));

    //            var user = await _userManager.FindByNameAsync(username);
    //            var roleresult = await _userManager.AddToRoleAsync(user, role);
    //            await _uow.SaveChangesAsync();
    //            return Ok();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }
    //}
}
