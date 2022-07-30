using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.System.Models;
using School.System.Repository;
using School.System.ViewModels;
using static School.System.ViewModels.StudentViewModel;

namespace School.System.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(
            IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public (bool, string) Create(StudentCreateViewModel model)
        {
            try
            {
                var student = new Student()
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    CreatedDate = DateTime.Now
                };
                return studentRepository.Create(student);
            }
            catch(Exception ex)
            {
                return (false, ex.Message);
            }
        }


        //concept of soft delete

        public (bool, string) SoftDelete (int id)
        {
            try
            {
                var existing = studentRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                existing.IsDeleted =true;
                return studentRepository.Edit(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) HardDelete(int id)
        {
            try
            {
                var existing = studentRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                return studentRepository.Delete(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }

    public interface IStudentService
    {
        (bool, string) Create(StudentCreateViewModel model);
        (bool, string) HardDelete(int id);
        (bool, string) SoftDelete(int id);
    }
}
