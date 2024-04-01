using ManageJobs.Models;
using ManageJobs.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ManageJobs.Repository.Implementation
{
    public class JobService : IJobServerice
    {
        private readonly DatabaseContext context;
        public JobService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool CreateJob(Jobs job)
        {
            context.Jobs.Add(job);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Jobs> GetAll()
        {
            var dta = (from job in context.Jobs
                       join department in context.Departments on job.Id equals department.Id
                       join
                       location in context.Locations on job.Id equals location.Id
                       select new Jobs
                       {
                           Id = job.Id,
                           Code = job.Code,
                           Title = job.Title,
                           Department = job.Department,
                           Location = job.Location,
                           ClosingDate = job.ClosingDate,
                           PostedDate = job.PostedDate,
                       }).ToList();
            return dta;
        }

        public Jobs GetJobsById(int id)
        {
            var data = (from job in context.Jobs
                        join department in context.Departments on job.Department equals department.Title
                        join location in context.Locations on job.Location equals location.Title
                        select new Jobs
                        {
                            Id = job.Id,
                            Code = job.Code,
                            Title = job.Title,
                            Department=job.Department,
                            Location = job.Location,
                            ClosingDate = job.ClosingDate,
                            PostedDate = job.PostedDate,
                        });
            return data;
            
        }

        public bool UpdateJob(Jobs job, int id)
        {
            var dta = context.Jobs.Find(job.Id);
            if (dta != null && job.Id == id)
            {
                dta.Title = job.Title;
                //dta.Description = job.Description;
                dta.Department = job.Department;
                dta.Location = job.Location;
                dta.ClosingDate = job.ClosingDate;

                context.Jobs.Update(dta);
                context.SaveChanges();
                return true;
            }
            else { return false; }
        }

    }
}
