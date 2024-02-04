using FormulaOne.DataService.data;
using FormulaOne.DataService.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repos
{
    public class GeneracRepo<T>(ILogger logger, AppDbContext dbContext) : IGenericRepo<T> where T : class
    {
        public readonly ILogger logger =logger;

        protected AppDbContext dbContext=dbContext;

        internal DbSet<T> dbSet=dbContext.Set<T>() ;


        public virtual async Task<bool> Create(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $" Error Occurs in GenericRepo while processing  Create method of {typeof(T)} entity");
                return false;
            }
        }

        public virtual Task<IEnumerable<T>> GetALL()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T?> GetSingle(Guid Id)
        {
            var entity = await dbSet.FindAsync(Id);
            return entity;

        }

        public virtual Task<bool> Remove(Guid Id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpDate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
