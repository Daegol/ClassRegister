using System;
using System.Collections.Generic;
using ClassRegister.Core.Model;
using ClassRegister.Services.DTOs;

namespace ClassRegister.Services.Mappers
{
    public static class MyMapper
    {
        public static Student UpdateStudentMap(UpdateStudentDto studentDto, Student student)
        {
            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            student.Email = studentDto.Email;
            student.Pesel = studentDto.Pesel;
            student.PhoneNumber = studentDto.PhoneNumber;
            student.Street = studentDto.Address.Substring(0, studentDto.Address.IndexOf(' '));
            studentDto.Address = studentDto.Address.Remove(0, studentDto.Address.IndexOf(' ') + 1);
            student.HouseNumber = studentDto.Address.Substring(0, studentDto.Address.IndexOf(' '));
            studentDto.Address = studentDto.Address.Remove(0, studentDto.Address.IndexOf(' ') + 1);
            student.PostCode = studentDto.Address.Substring(0, studentDto.Address.IndexOf(' '));
            studentDto.Address = studentDto.Address.Remove(0, studentDto.Address.IndexOf(' ') + 1);
            student.City = studentDto.Address.Substring(0, studentDto.Address.Length);
            return student;
        }

        public static Teacher UpdateTeacherMap(UpdateTeacherDto teacherDto, Teacher teacher)
        {
            teacher.FirstName = teacherDto.FirstName;
            teacher.LastName = teacherDto.LastName;
            teacher.Email = teacherDto.Email;
            teacher.Pesel = teacherDto.Pesel;
            teacher.PhoneNumber = teacherDto.PhoneNumber;
            teacher.Street = teacherDto.Address.Substring(0, teacherDto.Address.IndexOf(' '));
            teacherDto.Address = teacherDto.Address.Remove(0, teacherDto.Address.IndexOf(' ') + 1);
            teacher.HouseNumber = teacherDto.Address.Substring(0, teacherDto.Address.IndexOf(' '));
            teacherDto.Address = teacherDto.Address.Remove(0, teacherDto.Address.IndexOf(' ') + 1);
            teacher.PostCode = teacherDto.Address.Substring(0, teacherDto.Address.IndexOf(' '));
            teacherDto.Address = teacherDto.Address.Remove(0, teacherDto.Address.IndexOf(' ') + 1);
            teacher.City = teacherDto.Address.Substring(0, teacherDto.Address.Length);
            return teacher;
        }

        public static Admin UpdateAdminMap(UpdateAdminDto adminDto, Admin admin)
        {
            admin.FirstName = adminDto.FirstName;
            admin.LastName = adminDto.LastName;
            admin.Email = adminDto.Email;
            admin.Pesel = adminDto.Pesel;
            admin.PhoneNumber = adminDto.PhoneNumber;
            admin.Street = adminDto.Address.Substring(0, adminDto.Address.IndexOf(' '));
            adminDto.Address = adminDto.Address.Remove(0, adminDto.Address.IndexOf(' ') + 1);
            admin.HouseNumber = adminDto.Address.Substring(0, adminDto.Address.IndexOf(' '));
            adminDto.Address = adminDto.Address.Remove(0, adminDto.Address.IndexOf(' ') + 1);
            admin.PostCode = adminDto.Address.Substring(0, adminDto.Address.IndexOf(' '));
            adminDto.Address = adminDto.Address.Remove(0, adminDto.Address.IndexOf(' ') + 1);
            admin.City = adminDto.Address.Substring(0, adminDto.Address.Length);
            return admin;
        }

        public static Parent UpdateParentMap(UpdateParentDto parentDto, Parent parent)
        {
            parent.FirstName = parentDto.FirstName;
            parent.LastName = parentDto.LastName;
            parent.Email = parentDto.Email;
            parent.Pesel = parentDto.Pesel;
            parent.PhoneNumber = parentDto.PhoneNumber;
            parent.Street = parentDto.Address.Substring(0, parentDto.Address.IndexOf(' '));
            parentDto.Address = parentDto.Address.Remove(0, parentDto.Address.IndexOf(' ') + 1);
            parent.HouseNumber = parentDto.Address.Substring(0, parentDto.Address.IndexOf(' '));
            parentDto.Address = parentDto.Address.Remove(0, parentDto.Address.IndexOf(' ') + 1);
            parent.PostCode = parentDto.Address.Substring(0, parentDto.Address.IndexOf(' '));
            parentDto.Address = parentDto.Address.Remove(0, parentDto.Address.IndexOf(' ') + 1);
            parent.City = parentDto.Address.Substring(0, parentDto.Address.Length);
            return parent;
        }

        public static Class AddClassMap(ClassToAddDto classToAdd, Class cl)
        {
            cl.TeacherId = classToAdd.TutorId;
            cl.Name = classToAdd.Name;
            return cl;
        }
    }
}