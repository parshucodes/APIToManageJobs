using ManageJobs.Models;
using ManageJobs.Repository.Abstract;

namespace ManageJobs.Repository.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DatabaseContext context;
        public DepartmentService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool CreateDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public bool UpdateDepartment(Department department, int id)
        {
            var dept = context.Departments.Find(department.Id);
            if (department.Id==id)
            {
                dept.Title = department.Title;
                context.Departments.Update(dept);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Department GetDepartmentById(int id) 
        {
            return context.Departments.FirstOrDefault(c => c.Id == id);
        }
    }
}
