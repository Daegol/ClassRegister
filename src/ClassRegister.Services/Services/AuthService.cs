using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Infrastructure.Authorization;
using ClassRegister.Services.IServices;

namespace ClassRegister.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IAdminRepository _adminRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IParentRepository _parentRepository;

        public AuthService(IJwtHandler jwtHandler, IAdminRepository adminRepository,
            IParentRepository parentRepository, IStudentRepository studentRepository,
            ITeacherRepository teacherRepository)
        {
            _jwtHandler = jwtHandler;
            _adminRepository = adminRepository;
            _parentRepository = parentRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<string> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var student = await _studentRepository.GetByEmail(username);

            if (student != null)
                return !_jwtHandler.VerifyPasswordHash(password, student.PasswordHash, student.PasswordSalt)
                    ? null
                    : _jwtHandler.CreateToken(student);
            var teacher = await _teacherRepository.GetByEmail(username);
            if (teacher != null)
                return !_jwtHandler.VerifyPasswordHash(password, teacher.PasswordHash, teacher.PasswordSalt)
                    ? null
                    : _jwtHandler.CreateToken(teacher);
            var parent = await _parentRepository.GetByEmail(username);
            if (parent != null)
                return !_jwtHandler.VerifyPasswordHash(password, parent.PasswordHash, parent.PasswordSalt)
                    ? null
                    : _jwtHandler.CreateToken(parent);
            var admin = await _adminRepository.GetByEmail(username);
            if (admin == null) return null;
            return !_jwtHandler.VerifyPasswordHash(password, admin.PasswordHash, admin.PasswordSalt) ? null : _jwtHandler.CreateToken(admin);

        }

        public async Task Register(string role, string firstName, string lastName, string email, string phoneNumber,
            string pesel,
            string postCode, string city, string street, string houseNumber, string password)
        {
            if (await IfExistTask(email, pesel)) throw new Exception("User already exist");

            var hmac = new HMACSHA512();

            switch (role)
            {
                case "Student":
                    var studentToCreate = new Student(Guid.NewGuid(), role, firstName,
                        hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), hmac.Key, lastName, email,
                        phoneNumber, pesel, postCode, city, street, houseNumber);

                    await _studentRepository.AddStudent(studentToCreate);
                    break;
                case "Parent":
                    var parentToCreate = new Parent(Guid.NewGuid(), role, firstName,
                        hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), hmac.Key, lastName, email,
                        phoneNumber, pesel, postCode, city, street, houseNumber);
                    await _parentRepository.AddParent(parentToCreate);
                    break;
                case "Teacher":
                    var teacherToCreate = new Teacher(Guid.NewGuid(), role, firstName,
                        hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), hmac.Key, lastName, email,
                        phoneNumber, pesel, postCode, city, street, houseNumber);
                    await _teacherRepository.AddTeacher(teacherToCreate);
                    break;
                case "Admin":
                    var adminToCreate = new Admin(Guid.NewGuid(), role, firstName,
                        hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), hmac.Key, lastName, email,
                        phoneNumber, pesel, postCode, city, street, houseNumber);
                    await _adminRepository.AddAdmin(adminToCreate);
                    break;
                default:
                    throw new Exception("Something went wrong");
            }
        }

        private async Task<bool> IfExistTask (string email, string pesel)
        {
            var student = await _studentRepository.GetByEmail(email);
            if (student != null) return true;
            student = await _studentRepository.GetByPesel(pesel);
            if (student != null) return true;

            var teacher = await _teacherRepository.GetByEmail(email);
            if (teacher != null) return true;
            teacher = await _teacherRepository.GetByPesel(pesel);
            if (teacher != null) return true;

            var admin = await _adminRepository.GetByEmail(email);
            if (admin != null) return true;
            admin = await _adminRepository.GetByPesel(pesel);
            if (admin != null) return true;

            var parent = await _parentRepository.GetByEmail(email);
            if (parent != null) return true;
            parent = await _parentRepository.GetByPesel(pesel);
            if (parent != null) return true;

            return false;
        }

    }
}