using Application.Interfaces.Repositories.ResturantRepository;
using Domain.Models;
using Infrastructure.Data.Common;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ResturantRepository : GenericRepository<Resturant>, IResturantRepository
    {
        public ResturantRepository(ApplicationDbContext context) : base(context)
        {
        }

        public  IQueryable<Resturant> GetAllResturantsAndTheJoins()
        {
            var list = context.Resturants
                        .Include(r => r.Openings)
                           .ThenInclude(oh => oh.Days)
                        .Include(r => r.Images).AsQueryable();


            return list;
        }

        public Resturant? GetSingleResturantsAndTheJoins(int id)
        {
            var resturant = context.Resturants
                        .Include(r => r.Openings)
                           .ThenInclude(oh => oh.Days)
                        .Include(r => r.Images).FirstOrDefault(x => x.Id == id);


            return resturant;
        }
    }
}
