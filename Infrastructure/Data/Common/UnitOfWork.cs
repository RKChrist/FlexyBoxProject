using Application.Interfaces.Repositories.Common;
using Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {

            return await context.SaveChangesAsync();
        }
    }
}
