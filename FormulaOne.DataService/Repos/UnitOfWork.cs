using FormulaOne.DataService.data;
using FormulaOne.DataService.Repos.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repos
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext,ILoggerFactory loggerFactory )
        {
            this.dbContext = dbContext;
            var logger= loggerFactory.CreateLogger("logs");

            Drivers = new DriverRepo(logger,dbContext);
            Achivements= new AchivmentRepo(logger,dbContext);
        }
        public IDriverRepo Drivers { get; }
        public IAchivmentRepo Achivements { get; }


        public async Task<bool> CompleteAsync()
        {
            var result = await dbContext.SaveChangesAsync();
            return result>0;
        }   

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
