using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyMakerApi.Core.Controllers;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Domain.Services.Interfaces;

namespace SurveyMakerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : MainController
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        #region Get Profile
        /// <summary>
        /// Get Profile
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var response = await _usersService.GetProfile(GetUserId());
            return Ok(response);
        }
        #endregion

        #region Edit Profile
        /// <summary>
        /// Edit Profile
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileDTO input)
        {
            var response = await _usersService.EditProfile(GetUserId(), input);
            return Ok(response);
        }
        #endregion

        #region Change Password
        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO input)
        {
            await _usersService.ChangePassword(GetUserId(), input);
            return Ok();
        }
        #endregion


    }
}
