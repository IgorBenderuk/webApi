using DataService.Repos;
using FormulaOne.DataService.data;
using FormulaOne.DataService.Repos.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repos
{
    public class DriverRepo : GeneracRepo<Driver>, IDriverRepo
    {
        public DriverRepo(ILogger logger, AppDbContext dbContext) : base(logger, dbContext)
        {
        }

        public override async Task<IEnumerable<Driver>> GetALL()
        {
            try
            {
                return await dbSet.Where(d => d.Status == 1)
                    .AsSingleQuery()
                    .OrderBy(d => d.CreationDate).ToListAsync();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"driver repo GetAll ,{typeof(DriverRepo)}");
                throw;
            }
        }

        public override async Task<bool> Remove(Guid Id)
        {
            try
            {
                var driver = await GetSingle(Id);
                if (driver == null)
                {
                    return false;
                }
                dbSet.Remove(driver);

                driver.Status = 0;
                driver.UpdationDate = DateTime.UtcNow;

                return true;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"driver repo Remove,{typeof(DriverRepo)}");
                throw;
            }
        }

        public override async Task<bool> UpDate(Driver driver)
        {
            try
            {
                var existingDriver = await GetSingle(driver.Id);
                if (existingDriver == null) return false;

                existingDriver.UpdationDate = DateTime.UtcNow;
                existingDriver.DriverNumber = driver.DriverNumber;
                existingDriver.FirstName = driver.FirstName;
                existingDriver.LastName = driver.LastName;
                existingDriver.DataOfBirth = driver.DataOfBirth;

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"driver repo Update,{typeof(DriverRepo)}");
                throw;
            }
        }


    }
}