using DataService.Repos;
using FormulaOne.DataService.data;
using FormulaOne.DataService.Repos.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repos
{
    public class AchivmentRepo(ILogger logger, AppDbContext dbContext) : GeneracRepo<Achivment>(logger, dbContext), IAchivmentRepo
    {
        public async Task<IEnumerable<Achivment>?> GetDriverAchivmentsAasync(Guid driverId)
        {
            try
            {
                return await dbSet.Where(a => a.DriverId == driverId).ToListAsync();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"AchivmentRepo GetDriverAchivnebtsAsync ,{typeof(DriverRepo)}");
                throw;
            }
        }

        public override async Task<IEnumerable<Achivment>> GetALL()
        {
            try
            {
                return await dbSet.ToListAsync();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"AchivmentRepo GetAll,{typeof(AchivmentRepo)}");
                throw;
            }

        }

        public override async Task<bool> Remove(Guid Id)
        {
            try
            {
                var achivment = await GetSingle(Id);
                if (achivment == null)
                {
                    return false;
                }
                dbSet.Remove(achivment);

                achivment.Status = 0;
                achivment.UpdationDate = DateTime.UtcNow;

                return true;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"AchivmentRepo Remove,{typeof(AchivmentRepo)}");
                throw;
            }
        }

        public override async Task<bool> UpDate(Achivment achivment)
        {
            try
            {
                var esistingAchivment = await GetSingle(achivment.Id);
                if (esistingAchivment == null) return false;

                esistingAchivment.UpdationDate = DateTime.UtcNow;
                esistingAchivment.FastestLap = achivment.FastestLap;
                esistingAchivment.PolePosition = achivment.PolePosition;
                esistingAchivment.WorldChampionship = achivment.WorldChampionship;
                esistingAchivment.RaceWins = achivment.RaceWins;

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"AchivmentRepo UpDate,{typeof(AchivmentRepo)}");
                throw;
            }
        }


    }
}
