using e_gradebookAPI.Data;
using e_gradebookAPI.Dtos;
using e_gradebookAPI.Middleware.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _dbContext;
        private readonly IPasswordHasher<Student> _studentPasswordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(AppDbContext dbContext, IPasswordHasher<Student> studentPasswordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _studentPasswordHasher = studentPasswordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task RegisterNewStudent(RegisterStudentDto dto)
        {
            var newStudent = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                GradeYear = dto.GradeYear,
                Email = dto.Email
            };
            var temporaryPassword = GenerateRandomTemporaryStringPassword();
            Console.WriteLine(temporaryPassword);

            var hashedPassword = _studentPasswordHasher.HashPassword(newStudent, temporaryPassword);
            newStudent.PasswordHash = hashedPassword;

            //TODO: send temporary password to student email address

            await _dbContext.Students.AddAsync(newStudent);
            await _dbContext.SaveChangesAsync();
        }

        public Task RegisterNewTeacher(RegisterTeacherDto dto)
        {
            throw new NotImplementedException();
        }



        private static string GenerateRandomTemporaryStringPassword()
        {
            int length = 10;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _dbContext.Students
                .FirstOrDefault(z => z.Email == dto.Email);

            if (user is null)
                throw new BadRequestException("Invalid username or password");

            var result = _studentPasswordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new BadHttpRequestException("Invalid username or password");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
                
        }
    }
}
