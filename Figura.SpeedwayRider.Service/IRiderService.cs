using Figura.SpeedwayRider.Model.DAO;

namespace Figura.SpeedwayRider.Service
{
    public interface IRiderService
    {
        public Task<List<Rider>> GetAllRiders();
        public Task<Rider> AddRider(Rider rider);
        public Task<List<Rider>> FindByInititals(List<Rider> initials);
    }
}
