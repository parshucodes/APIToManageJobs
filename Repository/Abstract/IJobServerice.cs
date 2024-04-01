using ManageJobs.Models;

namespace ManageJobs.Repository.Abstract
{
    public interface IJobServerice
    {
        IEnumerable<Jobs> GetAll();
        Jobs GetJobsById(int id);
        bool CreateJob(Jobs job);
        bool UpdateJob(Jobs job, int id);
    }
}
