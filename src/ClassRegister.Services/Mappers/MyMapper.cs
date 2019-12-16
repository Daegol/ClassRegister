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
            if (parentDto.Id != "empty") parent.StudentId = Guid.Parse(parentDto.Id);
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
            var groups = subject.Lessons.Select(GroupsAssignedToSubject);
            subjectDto.GroupsAssignedToSubject = groups.ToHashSet();
            return subjectDto;
        }

        public static Subject UpdateSubjectMap(UpdateSubjectDto updateSubject, Subject subject, ITeacherRepository teacherRepository)
        {
            subject.Name = updateSubject.Name;
            subject.TeacherId = teacherRepository.GetByPesel(updateSubject.TeacherPesel).Result.Id;
            return subject;
        }

        public static LessonDto LessonMap(Lesson lesson)
        {
            var lessonDto = new LessonDto();
            lessonDto.LessonHour = lesson.LessonHour;
            lessonDto.SubjectName = lesson.Subject.Name;
            lessonDto.TeacherName = lesson.Teacher.FirstName + " " + lesson.Teacher.LastName;
            lessonDto.DatabaseId = lesson.Id;
            return lessonDto;
        }

        public static PlanDto PlanMap(Class cl)
        {
            var planDto = new PlanDto();
            if(cl.Lessons.Count() == 0)
            {
                planDto.IsExisting = false;
                return planDto;
            }
            planDto.IsExisting = true;
            planDto.Monday = cl.Lessons.Where(x => x.DayOfTheWeek == "Monday").Select(x => LessonMap(x));
            planDto.Monday = planDto.Monday.OrderBy(x => x.LessonHour);
            planDto.Tuesday = cl.Lessons.Where(x => x.DayOfTheWeek == "Tuesday").Select(x => LessonMap(x));
            planDto.Tuesday = planDto.Tuesday.OrderBy(x => x.LessonHour);
            planDto.Wednesday = cl.Lessons.Where(x => x.DayOfTheWeek == "Wednesday").Select(x => LessonMap(x));
            planDto.Wednesday = planDto.Wednesday.OrderBy(x => x.LessonHour);
            planDto.Thursday = cl.Lessons.Where(x => x.DayOfTheWeek == "Thursday").Select(x => LessonMap(x));
            planDto.Thursday = planDto.Thursday.OrderBy(x => x.LessonHour);
            planDto.Friday = cl.Lessons.Where(x => x.DayOfTheWeek == "Friday").Select(x => LessonMap(x));
            planDto.Friday = planDto.Friday.OrderBy(x => x.LessonHour);
            return planDto;
        }

        public static async Task LessonToAddMap(LessonToAddDto lessonToAdd, string day, 
            ISubjectRepository subjectRepository, Guid classId, ILessonRepository lessonRepository)
        {
            var lesson = new Lesson();
            lesson.DayOfTheWeek = day;
            lesson.LessonHour = lessonToAdd.LessonHour;
            lesson.SubjectId = Guid.Parse(lessonToAdd.SubjectId);
            lesson.ClassId = classId;
            lesson.TeacherId = subjectRepository.GetById(lesson.SubjectId.Value).Result.TeacherId;
            lesson.Id = Guid.NewGuid();
            await lessonRepository.AddLesson(lesson);
        }

        public static GradesDto GradesMap(Grade grade)
        {
            var grades = new GradesDto();
            grades.Id = grade.Id;
            grades.Type = grade.Type;
            grades.Value = grade.Value;
            return grades;
        }

        public static StudentsToGrade StudentsToGradeMap(Student student, Guid subjectId)
        {
            var studentToGrade = new StudentsToGrade();
            studentToGrade.FirstName = student.FirstName;
            studentToGrade.LastName = student.LastName;
            studentToGrade.Pesel = student.Pesel;
            studentToGrade.Grades = student.Grades.Where(x => x.SubjectId == subjectId).Select(GradesMap);
            return studentToGrade;
        }

        public static Grade GradeToAddMap(GradeToAdd gradeToAdd, IStudentRepository studentRepository)
        {
            var grade = new Grade();
            grade.Id = Guid.NewGuid();
            grade.Type = gradeToAdd.Type;
            grade.Value = gradeToAdd.Value;
            grade.StudentId = studentRepository.GetByPesel(gradeToAdd.StudentPesel).Result.Id;
            grade.SubjectId = gradeToAdd.SubjectId;
            return grade;
        }

        public static Grade GradeToUpdateMap(GradeToUpdate gradeToUpdate, Grade grade)
        {
            grade.Type = gradeToUpdate.Type;
            grade.Value = gradeToUpdate.Value;
            return grade;
        }

        public static StudentDto StudentMap(Student student)
        {
            var studentDto = new StudentDto();
            studentDto.Address = student.Street + " " + student.HouseNumber + "\n" + student.PostCode + " " +
                                 student.City;
            studentDto.Email = student.Email;
            studentDto.FirstName = student.FirstName;
            studentDto.LastName = student.LastName;
            if (student.Parent != null) studentDto.ParentPesel = student.Parent.Pesel;
            else studentDto.ParentPesel = "Nie przypisano rodzica";
            studentDto.PhoneNumber = student.PhoneNumber;
            studentDto.Pesel = student.Pesel;
            return studentDto;
        }

        public static ParentDto ParentMap(Parent parent)
        {
            var parentDto = new ParentDto();
            parentDto.Address = parent.Street + " " + parent.HouseNumber + "\n" + parent.PostCode + " " +
                                 parent.City;
            parentDto.Email = parent.Email;
            parentDto.FirstName = parent.FirstName;
            parentDto.LastName = parent.LastName;
            if (parent.Student != null) parentDto.ParentPesel = parent.Student.Pesel;
            else parentDto.ParentPesel = "Nie przypisano dziecka";
            parentDto.PhoneNumber = parent.PhoneNumber;
            parentDto.Pesel = parent.Pesel;
            return parentDto;
        }

        public static StudentToParentDto StudentToParentMap(Student student)
        {
            var studentTo = new StudentToParentDto();
            studentTo.Id = student.Id;
            studentTo.FirstName = student.FirstName;
            studentTo.LastName = student.LastName;
            studentTo.Pesel = student.Pesel;
            return studentTo;
        }
    }
}