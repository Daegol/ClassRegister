using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClassRegister.Core.Repositories;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using ClassRegister.Services.Mappers;

namespace ClassRegister.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminDto>> GetAdmins()
        {
            var admins = await _adminRepository.Get();
            var adminDtos = _mapper.Map<IEnumerable<AdminDto>>(admins);
            int id = 1;
            foreach (var admin in adminDtos)
            {
                admin.Id = id;
                id++;
            }

            return adminDtos;
        }

        public async Task DeleteAdmin(string pesel)
        {
            await _adminRepository.DeleteAdmin(pesel);
        }

        public async Task UpdateAdmin(UpdateAdminDto adminDto)
        {
            var admin = await _adminRepository.GetByPesel(adminDto.Pesel);
            admin = MyMapper.UpdateAdminMap(adminDto, admin);
            await _adminRepository.UpdateAdmin(admin);
        }
    }
}