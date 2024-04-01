using ManageJobs.Models;
using ManageJobs.Repository.Abstract;

namespace ManageJobs.Repository.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly DatabaseContext context;
        public LocationService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool CreateLocation(Location location)
        {
            try
            {
                context.Locations.Add(location);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public IEnumerable<Location> GetAll()
        {
            return context.Locations.ToList();
        }

        public Location GetLocationById(int id)
        {
            return context.Locations.FirstOrDefault(c=>c.Id==id);
        }

        public bool UpdateLocation(Location location, int id)
        {
            var target = context.Locations.Find(location.Id);
            if (target != null && location.Id == id)
            {
                target.State = location.State;
                target.Title = location.Title;
                target.City = location.City;
                target.Country = location.Country;
                target.Zip = location.Zip;

                context.Locations.Update(target);
                context.SaveChanges();
                return true;
            
            }
            else
            {
                return false;
            }
        }
    }
}
