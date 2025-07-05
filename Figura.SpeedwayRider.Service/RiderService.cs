using Figura.SpeedwayRider.Model;
using Figura.SpeedwayRider.Model.DAO;
using Microsoft.EntityFrameworkCore;

namespace Figura.SpeedwayRider.Service
{
    public class RiderService : IRiderService
    {
        private readonly SpeedwayRiderDb _context;

        public RiderService(SpeedwayRiderDb context)
        {
            _context = context;
        }

        public async Task<Rider> AddRider(Rider rider)
        {
            try
            {
                _context.Add(rider);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            IQueryable<Rider> query = _context.Riders.Where(x => x.Name.Equals(rider.Name) && x.Surname.Equals(rider.Surname));

            var res = query.FirstOrDefault();

            if (res == null)
            {
                throw new Exception("Adding rider fails - rider has not ended up in database");
            }

            return res;
        }

        public async Task<List<Rider>> FindByInititals(List<Rider> ridersToFetch)
        {
            var fullnames = ridersToFetch.Select(x => $"{x.Surname[0] + x.Surname.Substring(1).ToLower()}").ToList();

            IQueryable<Rider> query = _context.Riders.Where(x => fullnames.Contains(x.Surname));

            try
            {
                List<Rider> riders = await query.ToListAsync();

                return riders;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return [];
        }

        public async Task<List<Rider>> GetAllRiders()
        {
            IQueryable<Rider> query = _context.Riders;

            List<Rider> riders = null!;

            try
            {
                riders = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            if (riders == null)
            {
                throw new Exception("Get all riders exception");
            }

            return riders;
        }
    }
}
