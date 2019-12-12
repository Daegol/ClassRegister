﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Services.DTOs;

namespace ClassRegister.Services.IServices
{
    public interface IClassService
    {
        Task AddClass(ClassToAddDto group);
        Task<IEnumerable<ClassesDto>> GetClasses();
        Task DeleteClass(Guid id);
    }
}