using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.System.Data;
using School.System.Models;

//Database ko CRUD Operation matra garne validation garne kaam services ma huncha

namespace School.System.Repository
{
    public interface IStudentRepository
    {
        (bool, string) Create(Student model);
        (bool, string) Delete(Student model);
        (bool, string) Edit(Student model);
        IQueryable<Student> GetAll();
        Student GetById(int id);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext db;
        public StudentRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IQueryable<Student> GetAll()
        {
            //basic return db.Students;
            return db.Students.Where(p => !p.Isdeleted);
        }

        public Student GetById(int id)

        {
            //basic return db.Students.Find(id);
            var existing = db.Students.Find(id);
            if ((existing == null) || existing.Isdeleted)
                    return null;
            return existing;
        }

        public (bool, string) Create(Student model)
        {
            try
            {
                db.Students.Add(model);
                db.SaveChanges();
                return (true, "It is added successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Edit(Student model)
        {
            try
            {
                db.Students.Update(model);
                db.SaveChanges();
                return (true, "It is updated successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public (bool, string) Delete(Student model)
        {
            try
            {
                //concept of hard delete
                //var existing = db.Students.Find(model.Id);
                //if (existing == null)
                    //return (false, "Not Found");
                //existing.Isdeleted = true;
                

                db.Students.Remove(model);
                db.SaveChanges();
                return (true, "It is deleted successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

    }
}
