using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
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

        public static StudentToGroupDto StudentToGroup(Student student, IClassRepository classRepository)
        {
            var studentToGroupDto = new StudentToGroupDto();
            studentToGroupDto.FirstName = student.FirstName;
            studentToGroupDto.LastName = student.LastName;
            studentToGroupDto.Pesel = student.Pesel;
            studentToGroupDto.IsAssigned = false;
            studentToGroupDto.StudentClass = 
                student.ClassId != null ? classRepository.GetById(student.ClassId).Result.Name : "Brak przydziału";
            studentToGroupDto.Id = student.Id;
            return studentToGroupDto;
        }

        public static ClassesDto ClassesToSend(Class cl, ITeacherRepository teacherRepository)
        {
            var classesDto = new ClassesDto();
            classesDto.Name = cl.Name;
            classesDto.DatabaseId = cl.Id;
            classesDto.StudentsNumber = cl.Students.Count();
            var tutor = teacherRepository.GetById(cl.TeacherId).Result;
            classesDto.Tutor = tutor.FirstName + ' ' + tutor.LastName;
            classesDto.TutorPesel = tutor.Pesel;
            return classesDto;
        }

        public static StudentToGroupDto StudentToGroupEdit(Student student, IClassRepository classRepository, Guid classId)
        {
            var studentToGroupDto = new StudentToGroupDto();
            studentToGroupDto.FirstName = student.FirstName;
            studentToGroupDto.LastName = student.LastName;
            studentToGroupDto.Pesel = student.Pesel;
            studentToGroupDto.IsAssigned = student.ClassId == classId;
            studentToGroupDto.StudentClass =
                student.ClassId != null ? classRepository.GetById(student.ClassId).Result.Name : "Brak przydziału";
            studentToGroupDto.Id = student.Id;
            return studentToGroupDto;
        }

        public static Class UpdateClassMap(UpdateClassDto updateClass, Class cl, ITeacherRepository teacherRepository)
        {
            cl.Name = updateClass.Name;
            cl.TeacherId = teacherRepository.GetByPesel(updateClass.TutorId).Result.Id;
            return cl;
        }

        public static Subject AddSubjectMap(SubjectToAddDto subjectToAdd)
        {
            var subject = new Subject();
            subject.Name = subjectToAdd.Name;
            subject.Id = Guid.NewGuid();
            return subject;
        }

        public static ClassToSubjectDto GroupsAssignedToSubject(Lesson lesson)
        {
            if (lesson.Class == null) return null;
            var subjectClasses = new ClassToSubjectDto();
            subjectClasses.Name = lesson.Class.Name;
            subjectClasses.Id = lesson.Class.Id;
            subjectClasses.StudentsNumber = lesson.Class.Students.Count();
            return subjectClasses;
        }

        public static async Task<SubjectDto> SubjectToSend(Subject subject, ITeacherRepository teacherRepository)
        {
            var subjectDto = new SubjectDto();
            subjectDto.Name = subject.Name;
            subjectDto.DatabaseId = subject.Id;
            var teacher = await teacherRepository.GetById(subject.TeacherId);
            subjectDto.TeacherName = teacher.FirstName + ' ' + teacher.LastName;
            subjectDto.TeacherPesel = teacher.Pesel;
            subjectDto.GroupsAssignedToSubject = subject.Lessons.Select(GroupsAssignedToSubject);
            return subjectDto;
        }

        public static Subject UpdateSubjectMap(UpdateSubjectDto updateSubject, Subject subject, ITeacherRepository teacherRepository)
        {
            subject.Name = updateSubject.Name;
            subject.TeacherId = teacherRepository.GetByPesel(updateSubject.TeacherPesel).Result.Id;
            return subject;
        }
    }
}