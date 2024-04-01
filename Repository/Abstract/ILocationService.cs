using ManageJobs.Models;

namespace ManageJobs.Repository.Abstract
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAll();
        Location GetLocationById(int id);
        bool CreateLocation(Location location);
        bool UpdateLocation(Location location, int id);
    }
}
