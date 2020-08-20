using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Steam_Invest.BLL.DTO.BindingModel;
using Steam_Invest.DAL.Entities;
using Steam_Invest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steam_Invest.PRL.Controllers
{
    public class AccountController : Controller
    {
        IUnitOfWork _uow { get; set; }
        private readonly UserManager<AspNetUser> _userManager;
        private IMapper _mapper;
        public AccountController(IUnitOfWork uow, UserManager<AspNetUser> userManager, IMapper mapper)
        {
            _uow = uow;
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var emailcheck = await _uow.AspNetUsers.Query()
                    .Where(s => s.Email == model.Email)
                    .FirstOrDefaultAsync();
                if (emailcheck != null)
                {
                    ModelState.AddModelError("Email", "Данный email уже зарегистрирован");
                    return BadRequest(ModelState);
                }
                var user = new AspNetUser() { UserName = model.Email, Email = model.Email, EmailConfirmed = true };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var person = _mapper.Map<PersonInfo>(model);
                    person.AspNetUserId = user.Id;
                    _uow.PersonInfo.Add(person);
                    await _uow.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
