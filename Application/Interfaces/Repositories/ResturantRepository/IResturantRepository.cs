using Application.Interfaces.Repositories.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.ResturantRepository
{
    public interface IResturantRepository : IGenericRepository<Resturant>
    {
        IQueryable<Resturant> GetAllResturantsAndTheJoins();

        Resturant? GetSingleResturantsAndTheJoins(int id);
    }
}
