﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClassRegister.Core.Repositories;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using ClassRegister.Services.Mappers;

namespace ClassRegister.Services.Services
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;
        private readonly IMapper _mapper;

        public ParentService(IParentRepository parentRepository, IMapper mapper)
        {
            _parentRepository = parentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParentDto>> GetParents()
        {
            var parents = await _parentRepository.Get();
            var parentDtos = _mapper.Map<IEnumerable<ParentDto>>(parents);
            int id = 1;
            foreach (var parent in parentDtos)
            {
                parent.Id = id;
                id++;
            }

            return parentDtos; // parentDto.Select(MyMapper.MapParentToPatentDto).ToList();
        }

        public async Task DeleteParent(string pesel)
        {
            await _parentRepository.DeleteParent(pesel);
        }

        public async Task UpdateParent(UpdateParentDto parentDto)
        {
            var parent = await _parentRepository.GetByPesel(parentDto.Pesel);
            parent = MyMapper.UpdateParentMap(parentDto, parent);
            await _parentRepository.UpdateParent(parent);
        }
    }
}