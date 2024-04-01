using ManageJobs.Models;

namespace ManageJobs.Repository.Abstract
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();
        bool CreateDepartment(Department department);
        bool UpdateDepartment(Department department,int id);
        Department GetDepartmentById(int id);
    }
}
