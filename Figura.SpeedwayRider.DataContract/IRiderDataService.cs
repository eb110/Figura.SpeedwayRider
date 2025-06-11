using Figura.SpeedwayRider.Model.DAO;

namespace Figura.SpeedwayRider.DataContract
{
    public interface IRiderDataService
    {
        Task<List<Rider>> GetAllRiders(string url);

        Task<List<Rider>> FetchByInitials(List<Rider> initials);
    }
}
