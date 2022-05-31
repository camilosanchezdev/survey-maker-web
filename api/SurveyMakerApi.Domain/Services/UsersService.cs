using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SurveyMakerApi.Core.Domain.Services;
using SurveyMakerApi.Core.Exceptions;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Domain.Services.Interfaces;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services
{
    public class UsersService : Service<User>, IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _repository;
        public UsersService(IServiceProvider serviceProvider, IMapper mapper, IUsersRepository repository) : base(repository, serviceProvider)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #region User Login
        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UserDTO> Login(string email, string password)
        {
            try
            {
                var user = (await All()).Where(x => x.Email == email).SingleOrDefault();
                if(user != null && (new PasswordHasher<string>().VerifyHashedPassword(email, user.Password, password) == PasswordVerificationResult.Success))
                {
                    return _mapper.Map(user, new UserDTO());
                }
                else
                {
                    throw new UnAuthorizedException();
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region User Register
        /// <summary>
        /// User Register
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<UserDTO> Register(RegisterDTO input)
        {
            var transaction = _repository.BeginTransaction();
            try
            {
                if((await All()).Where(x => x.Email == input.Email).Any())
                {
                    throw new AlreadyExistsException();
                }

                var user = new User
                {
                    Email = input.Email,
                    Name = input.Name,
                    Password = new PasswordHasher<string>().HashPassword(input.Email, input.Password)
                };

                user = await Insert(user, transaction);
                transaction.Commit();
                return _mapper.Map(user, new UserDTO());
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        #endregion

        #region Change Password
        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<object> ChangePassword(int userId, ChangePasswordDTO input)
        {
            var transaction = _repository.BeginTransaction();
            try
            {
                var user = (await All()).Where(x => x.Id == userId).SingleOrDefault();
                if(user == null) throw new NotFoundException();

                if ((new PasswordHasher<string>().VerifyHashedPassword(user.Email, user.Password, input.OldPassword) == PasswordVerificationResult.Success))
                {
                    user.Password = new PasswordHasher<string>().HashPassword(user.Email, input.NewPassword);
                    var response = await Update(user, transaction);
                    transaction.Commit();
                    return response;

                } else
                {
                    throw new BadRequestException();
                }

            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        #endregion

        #region Edit Profile
        /// <summary>
        /// Edit Profile
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<object> EditProfile(int userId, EditProfileDTO input)
        {
            var transaction = _repository.BeginTransaction();
            try
            {
                var user = (await All()).Where(x => x.Id == userId).SingleOrDefault();
                if (user == null) throw new NotFoundException();

                if (input.Email == null || input.Name == null) throw new BadRequestException();
                user.Name = input.Name;
                user.Email = input.Email;
                await Update(user, transaction);
                transaction.Commit();
                return _mapper.Map(user, new UserDTO());

            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        #endregion

        #region Get Profile
        /// <summary>
        /// Get Profile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDTO> GetProfile(int userId)
        {
            try
            {
                var user = (await All()).Where(x => x.Id == userId).SingleOrDefault();
                if (user != null)
                {
                    return _mapper.Map(user, new UserDTO());
                }
                else
                {
                    throw new UnAuthorizedException();
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
