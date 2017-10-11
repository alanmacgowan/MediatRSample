using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace MediatRSample.Infrastructure
{

    public class DbContextTransactionFilter : IAsyncActionFilter
    {
        private readonly OrderProcessingContext _dbContext;

        public DbContextTransactionFilter(OrderProcessingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                _dbContext.BeginTransaction();

                await next();

                await _dbContext.CommitTransactionAsync();
            }
            catch (Exception)
            {
                _dbContext.RollbackTransaction();
                throw;
            }
        }
    }
}