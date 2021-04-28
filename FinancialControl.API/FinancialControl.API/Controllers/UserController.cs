using FinancialControl.API.DTOs;
using FinancialControl.BLL.Models;
using FinancialControl.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace FinancialControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            User user = await _userRepository.GetById(id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost("SaveUserPhoto")]
        public async Task<ActionResult> SaveUserPhoto()
        {
            var photo = Request.Form.Files[0];
            byte[] photoByte;

            using (Stream openReadStream = photo.OpenReadStream())
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await openReadStream.CopyToAsync(memoryStream);
                    photoByte = memoryStream.ToArray();
                }
            }

            return Ok(new
            {
                photo = photoByte
            });
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                string userRole;

                User user = new()
                {
                    UserName = registerDTO.UserName,
                    Email = registerDTO.Email,
                    PasswordHash = registerDTO.Password,
                    TaxNumber = registerDTO.TaxNumber,
                    Occupation = registerDTO.Occupation,
                    Photograph = registerDTO.Photograph
                };

                if (await _userRepository.GetUsersCount() > 0)
                    userRole = "User";
                else
                    userRole = "Administrator";

                IdentityResult createdUser = await _userRepository.CreateUser(user, registerDTO.Password);

                if (createdUser.Succeeded)
                {
                    await _userRepository.AddUserToRole(user, userRole);
                    await _userRepository.SignInUser(user, false);

                    return Ok(new
                    {
                        loggedUserEmail = user.Email,
                        userId = user.Id
                    });
                }
                else
                {
                    return BadRequest(registerDTO);
                }
            }

            return BadRequest(registerDTO);
        }
    }
}
